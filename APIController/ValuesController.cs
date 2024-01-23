using DummyPrintingWebApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace DummyPrintingWebApp.APIController
{
    [Route("api/v1/afi-desktop-printing")]
    public class ValuesController : Controller
    {
        public string base64 { get; set; } = "JVBERi0xLjEKJcKlwrHDqwoKMSAwIG9iagogIDw8IC9UeXBlIC9DYXRhbG9nCiAgICAgL1BhZ2VzIDIgMCBSCiAgPj4KZW5kb2JqCgoyIDAgb2JqCiAgPDwgL1R5cGUgL1BhZ2VzCiAgICAgL0tpZHMgWzMgMCBSXQogICAgIC9Db3VudCAxCiAgICAgL01lZGlhQm94IFswIDAgMzAwIDE0NF0KICA+PgplbmRvYmoKCjMgMCBvYmoKICA8PCAgL1R5cGUgL1BhZ2UKICAgICAgL1BhcmVudCAyIDAgUgogICAgICAvUmVzb3VyY2VzCiAgICAgICA8PCAvRm9udAogICAgICAgICAgIDw8IC9GMQogICAgICAgICAgICAgICA8PCAvVHlwZSAvRm9udAogICAgICAgICAgICAgICAgICAvU3VidHlwZSAvVHlwZTEKICAgICAgICAgICAgICAgICAgL0Jhc2VGb250IC9UaW1lcy1Sb21hbgogICAgICAgICAgICAgICA+PgogICAgICAgICAgID4+CiAgICAgICA+PgogICAgICAvQ29udGVudHMgNCAwIFIKICA+PgplbmRvYmoKCjQgMCBvYmoKICA8PCAvTGVuZ3RoIDU1ID4+CnN0cmVhbQogIEJUCiAgICAvRjEgMTggVGYKICAgIDAgMCBUZAogICAgKEhlbGxvIFdvcmxkKSBUagogIEVUCmVuZHN0cmVhbQplbmRvYmoKCnhyZWYKMCA1CjAwMDAwMDAwMDAgNjU1MzUgZiAKMDAwMDAwMDAxOCAwMDAwMCBuIAowMDAwMDAwMDc3IDAwMDAwIG4gCjAwMDAwMDAxNzggMDAwMDAgbiAKMDAwMDAwMDQ1NyAwMDAwMCBuIAp0cmFpbGVyCiAgPDwgIC9Sb290IDEgMCBSCiAgICAgIC9TaXplIDUKICA+PgpzdGFydHhyZWYKNTY1CiUlRU9GCg==";
        public ValuesController()
        {

        }

        [HttpGet("get-dummy-file")]
        public IActionResult GetDummyFile()
        {
            return Ok(base64);
        }

        [HttpGet("get-emsigner/{frameNumber}", Name = "Get Em Signer")]
        public IActionResult GetEmSignerData(string frameNumber)
        {
            return Ok(base64);
        }

        [HttpGet("get-file-support-document/{frameNumber}", Name = "Get file MinIO")]
        public IActionResult GetMinIOFile(string frameNumber)
        {
            var response = new List<AfiPrintAndReprintDocumentModel>();
            var dummyFile = new AfiPrintAndReprintDocumentModel
            {
                Base64 = base64,
                BlobId = Guid.NewGuid(),
                DocumentType = "Cek Fisik"
            };

            response.Add(dummyFile);

            return Ok(response);
        }


        [HttpGet("get-files-for-reprint/{frameNumber}", Name = "Get files for Reprint")]
        public IActionResult GetFilesForReprint(string frameNumber)
        {
            var response = new List<AfiPrintAndReprintDocumentModel>();
            var dummyFile = new AfiPrintAndReprintDocumentModel
            {
                Base64 = base64,
                BlobId = Guid.NewGuid(),
                DocumentType = "Cek Fisik"
            };

            response.Add(dummyFile);

            return Ok(response);
        }

        [HttpPost("validate-printer", Name = "Validate Printer")]
        public IActionResult ValidatePrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            var printerMapping = new AfiPrintAndReprintValidatePrinterResponseModel
            {
                Hostname = System.Net.Dns.GetHostName(),
                PrinterName = settings.PrinterName
            };
            if (printerMapping == null)
            {
                return BadRequest("Username tidak termapping");
            }
            return Ok(printerMapping);
        }
        
        [HttpPost("printing-success", Name = "Printing Success")]
        public IActionResult PrintingSuccess([FromBody] AfiPrintAndReprintSuccessModel data)
        {
            return Ok(true);
        }
        
        [HttpPost("reprinting-success", Name = "Reprinting Success")]
        public IActionResult ReprintingSuccess([FromBody] AfiPrintAndReprintSuccessModel data)
        {
            return Ok();
        }

        [HttpGet("get-blacklisted-printer-model", Name = "Get Blacklisted Printer Model")]
        public IActionResult GetBlacklistModel()
        {
            return Ok(string.Empty);
        }

        [HttpPost("single-reprinting-success/{frameNumber}", Name = "Single Reprinting")]
        public IActionResult SingleReprinting(string frameNumber)
        {
            return Ok(string.Empty);
        }


        [HttpPost("single-printing-success/{frameNumber}", Name = "Single Printing")]
        public IActionResult SinglePrinting(string frameNumber)
        {
            return Ok(string.Empty);
        }

        [HttpPost("send-log-to-server/{log}", Name = "Send Log")]
        public IActionResult SendLog(string log)
        {
            return Ok(string.Empty);
        }
    }
}
