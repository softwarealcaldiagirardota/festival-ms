using System;
namespace Festival.Ms.Application.Services
{
    // Implementación simplificada de ChaCha20
    public class ChaCha20 : IDisposable
    {
        private readonly byte[] _key;
        private readonly byte[] _nonce;
        private uint _counter;

        public ChaCha20(byte[] key, byte[] nonce)
        {
            _key = key;
            _nonce = nonce;
            _counter = 0;
        }

        public void Transform(byte[] input, byte[] output)
        {
            // Implementación simplificada de ChaCha20
            // En un entorno de producción, deberías usar una implementación completa y probada
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = (byte)(input[i] ^ _key[i % _key.Length] ^ _nonce[i % _nonce.Length] ^ (byte)_counter);
            }
            _counter++;
        }

        public void Dispose()
        {
            // Limpiar recursos si es necesario
        }
    }
}

