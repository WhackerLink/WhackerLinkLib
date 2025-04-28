using System;
using System.Collections.Concurrent;
using System.Threading;
using Serilog;
using WhackerLinkServer.Models;

namespace WhackerLinkLib.Vocoder
{
    /// <summary>
    /// 
    /// </summary>
    public class VocoderManager : IDisposable
    {
        private readonly ConcurrentDictionary<string, (MBEDecoder Decoder, MBEEncoder Encoder)> vocoderInstances;
        private readonly object lockObj = new object();
        private bool disposed = false;
        private readonly ILogger logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public VocoderManager(ILogger logger)
        {
            this.logger = logger;
            vocoderInstances = new ConcurrentDictionary<string, (MBEDecoder, MBEEncoder)>();
        }

        /// <summary>
        /// Retrieves or creates a vocoder instance for a given channel.
        /// </summary>
        public (MBEDecoder Decoder, MBEEncoder Encoder) GetOrCreateVocoder(string channelId, VocoderModes mode)
        {
            if (disposed) throw new ObjectDisposedException(nameof(VocoderManager));

            return vocoderInstances.GetOrAdd(channelId, _ =>
            {
                logger.Information("Created new vocoder instance for channel {ChannelId}", channelId);
                return CreateVocoderInstance(mode);
            });
        }

        /// <summary>
        /// Removes and disposes of a vocoder instance.
        /// </summary>
        public void RemoveVocoder(string channelId)
        {
            if (vocoderInstances.TryRemove(channelId, out var instance))
            {
                lock (lockObj)
                {
                    //instance.Decoder.Dispose();
                    //instance.Encoder.Dispose();
                    logger.Information("Removed vocoder instance for channel {ChannelId}", channelId);
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the vocoder in the given mode
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        private (MBEDecoder, MBEEncoder) CreateVocoderInstance(VocoderModes mode)
        {
            try
            {
                MBE_MODE mbeMode = mode == VocoderModes.IMBE ? MBE_MODE.IMBE_88BIT : MBE_MODE.DMR_AMBE;

                var decoder = new MBEDecoder(mbeMode);
                var encoder = new MBEEncoder(mbeMode);

                return (decoder, encoder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (null, null);
            }
        }

        /// <summary>
        /// Cleanup
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                foreach (var instance in vocoderInstances.Values)
                {
                    //instance.Decoder.Dispose();
                    //instance.Encoder.Dispose();
                }
                vocoderInstances.Clear();
                disposed = true;
            }
        }
    }
}
