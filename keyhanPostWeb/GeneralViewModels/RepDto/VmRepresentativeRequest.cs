namespace keyhanPostWeb.GeneralViewModels.RepDto
{
    public class VmRepresentativeRequest
    {
        public RepApplicantDetailDto Details { get; set; }
        public RepApplicantCreateDto_Step1 dtoStep1 { get; set; }
        public RepApplicantCreateDto_Step2 dtoStep2 { get; set; }

        public int CurrentStep { get; set; }
    }
}
