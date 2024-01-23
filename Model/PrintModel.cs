namespace DummyPrintingWebApp.Model
{
    public class PrintModel
    {
    }

    public class AfiPrintAndReprintDocumentModel
    {
        public Guid BlobId { get; set; }
        public string DocumentType { get; set; } = string.Empty;
        public string Base64 { get; set; } = string.Empty;
    }

    public class AfiPrintAndReprintValidatePrinterResponseModel
    {
        /// <summary>
        /// <seealso cref="AFIPrinterMapping.PrinterName"/>
        /// </summary>
        public string PrinterName { get; set; } = string.Empty;

        /// <summary>
        /// <seealso cref="AFIPrinterMapping.Hostname"/>
        /// </summary>
        public string Hostname { get; set; } = string.Empty;
    }

    public class AfiPrintAndReprintSuccessModel
    {
        public List<string> FrameNumbers { get; set; } = new List<string>();
    }
}
