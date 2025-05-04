using BaiTapOceanTech.Services;
using Quartz;

namespace BaiTapOceanTech.Utility
{
    public class MyCronJob : IJob
    {
        private readonly IEmployeeCertificateService _service;
        private readonly ILogger<MyCronJob> _logger;

        public MyCronJob(IEmployeeCertificateService service, ILogger<MyCronJob> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var ss = await _service.ScanAndUpdateCertificateAsync();
        }
    }
}
