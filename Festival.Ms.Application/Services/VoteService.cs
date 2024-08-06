using System;
using System.Security.Cryptography;
using System.Text;
using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DTO.Models;

namespace Festival.Ms.Application.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRespository;
        private readonly IDeviceParticipationRepository _deviceParticipationRespository;
        private readonly IParticipationCompanyRepository _participationCompanyRespository;

        private const string SecretKey = "TuClaveSecretaAqui123"; // company
        private static readonly byte[] Nonce = Encoding.ASCII.GetBytes("NonceSecretoAqui12"); // 12 bytes para ChaCha20
        const string claveSecreta = "clave_super_secreta_de_la_empresa";// codigo

        public VoteService(IVoteRepository voteRepository,
            IDeviceParticipationRepository deviceParticipation,
            IParticipationCompanyRepository participationCompanyRespository)
        {
            _voteRespository = voteRepository;
            _deviceParticipationRespository = deviceParticipation;
            _participationCompanyRespository = participationCompanyRespository;
        }

        //Desencrypt CompanyId code
        //Verify first code was born from CompanyId code
        //Create hash of code and insert int device_participation and return id
        //Insert vote
        public async Task<bool> RegistryVote(List<Vote> votes, string code, int IdFestival)
        {
            var codeEncodeSplit = SplitCodeEncode(code);
            var IdCompany = DecodeNumber(codeEncodeSplit.Item2);
            if (VerifyCode(codeEncodeSplit.Item2, IdCompany))
            {
                var IdParticipationCompany = 0;
                var IdDeviceParticipation = 0;
                var hash = CreateHash(code);
                //GetParticipationCompanyID
                IdParticipationCompany = await _participationCompanyRespository.GetIdByCompanyAndFestivalAsync(IdCompany, IdFestival);
                if (IdParticipationCompany == 0)
                {
                    return false;
                }
                //InsertDeviceParticipation
                var DevicePart = new DeviceParticipationEntity()
                {
                    Hash = hash,
                    IdParticipation = IdParticipationCompany
                };

                IdDeviceParticipation = await _deviceParticipationRespository.CreateAsync(DevicePart);
                if (IdDeviceParticipation == 0)
                {
                    return false;
                }
                var flag = true;
                //InsertVote manejar transaccion
                foreach (var item in votes)
                {
                    var Vote = new VoteEntity()
                    {
                        CreatedAt = DateTime.Now,
                        IdQuestion = item.IdQuestion,
                        IdAnswer = item.IdAnswer,
                        IdParticipationCompany = item.IdParticipationCompany
                    };

                    var IdVote = await _voteRespository.CreateAsync(Vote);
                    if (IdVote == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (!flag)
                {
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }


        public Task<int> CreateAsync(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vote>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vote> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Vote entity)
        {
            throw new NotImplementedException();
        }

        public static int DecodeNumber(string encodedString)
        {
            string paddedEncoded = encodedString.PadRight((encodedString.Length + 3) / 4 * 4, '=');
            byte[] decrypted = DecryptChaCha20(paddedEncoded);
            return BitConverter.ToInt32(decrypted, 0);
        }

        private static byte[] DecryptChaCha20(string encryptedString)
        {
            using (var chacha20 = new ChaCha20(DeriveKey(SecretKey, 32), Nonce))
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedString);
                byte[] decrypted = new byte[encryptedBytes.Length];
                chacha20.Transform(encryptedBytes, decrypted);
                return decrypted;
            }
        }

        private static byte[] DeriveKey(string password, int keySize)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, Nonce, 10000))
            {
                return deriveBytes.GetBytes(keySize);
            }
        }

        public static (string, string) SplitCodeEncode(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty");
            }

            var parts = input.Split('-');
            if (parts.Length != 2)
            {
                throw new ArgumentException("Input string must contain exactly one dash (-)");
            }

            return (parts[0], parts[1]);
        }

        static bool VerifyCode(string codigo, int companyId)
        {
            string cadena = $"{codigo}{companyId}{claveSecreta}";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(cadena));
                string hashHex = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return hashHex.EndsWith("00");
            }
        }

        public static string CreateHash(string code)
        {
            // Crear una instancia de SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computar el hash - devuelve un arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(code));

                // Convertir el arreglo de bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

