using System;
using System.Security.Cryptography;
using System.Text;
using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DTO.Models;
using Microsoft.Extensions.Logging;

namespace Festival.Ms.Application.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRespository;
        private readonly IDeviceParticipationRepository _deviceParticipationRespository;
        private readonly IParticipationCompanyRepository _participationCompanyRespository;
        private readonly ILogger<VoteService> _logger;
        string key = "8Y9ksCRQic9+roHrANRuoCce17o7H/2xtEiT72V+l6k=";
        private const string Base36Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string claveSecreta = "clave_super_secreta_de_la_empresa";
        private const int MaxValue = 46655; // 36^3 - 1

        public VoteService(IVoteRepository voteRepository,
            IDeviceParticipationRepository deviceParticipation,
            IParticipationCompanyRepository participationCompanyRespository,
            ILogger<VoteService> logger)
        {
            _voteRespository = voteRepository;
            _deviceParticipationRespository = deviceParticipation;
            _participationCompanyRespository = participationCompanyRespository;
            _logger = logger;
        }

        //Desencrypt CompanyId code
        //Verify first code was born from CompanyId code
        //Create hash of code and insert int device_participation and return id
        //Insert vote
        public async Task<bool> RegistryVote(List<Vote> votes, string code, int IdFestival)
        {
            var codeEncodeSplit = SplitCodeEncode(code);
            var IdCompany = DecodeNumber(codeEncodeSplit.Item2, key);
            if (IdCompany == 0)
            {
                return false;
            }
            if (VerifyCode(codeEncodeSplit.Item1, IdCompany))
            {
                var hash = CreateHash(code);
                //GetParticipationCompanyID
                var IdParticipationCompany = await _participationCompanyRespository.GetIdByCompanyAndFestivalAsync(IdCompany, IdFestival);
                if (IdParticipationCompany == null)
                {
                    return false;
                }
                //InsertDeviceParticipation
                var DevicePart = new DeviceParticipationEntity()
                {
                    Hash = hash,
                    IdParticipation = (long)IdParticipationCompany
                };

                var IdDeviceParticipation = await _deviceParticipationRespository.CreateAsync(DevicePart);
                if (IdDeviceParticipation == null)
                {
                    return false;
                }
                //InsertVote manejar transaccion
                var ListVotes = DAL.Mappers.VoteMapper.Map(votes, Convert.ToInt64(IdDeviceParticipation));

                return await _voteRespository.SaveEntitiesWithTransaction(ListVotes);
            }

            return await Task.FromResult(false);
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

        public int DecodeNumber(string encryptedValue, string key)
        {
            try
            {
                if (encryptedValue.Length != 5)
                    throw new ArgumentException("Invalid encrypted value length");

                string base36 = encryptedValue.Substring(0, 3);
                byte receivedChecksum = (byte)FromBase36(encryptedValue.Substring(3, 2));

                if (receivedChecksum != CalculateChecksum(base36))
                    throw new CryptographicException("Data integrity check failed");

                int encrypted = FromBase36(base36);

                using (var md5 = MD5.Create())
                {
                    byte[] keyBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                    int keyInt = BitConverter.ToInt32(keyBytes, 0) & MaxValue;

                    return (encrypted - keyInt + (MaxValue + 1)) % (MaxValue + 1); // Revertimos la operación de suma
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A typo error occurred.");
                return 0;
            }

        }

        private static byte CalculateChecksum(string value)
        {
            byte checksum = 0;
            foreach (char c in value)
            {
                checksum ^= (byte)c;
            }
            return checksum;
        }

        private static int FromBase36(string value)
        {
            int result = 0;
            foreach (char c in value.ToUpper())
            {
                result = result * 36 + Base36Chars.IndexOf(c);
            }
            return result;
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

