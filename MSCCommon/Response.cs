using System;
using System.Xml;

/// <summary>
/// Summary description for Error
/// </summary>
namespace MSCCommon
{
    public class Response
    {
        public int status { get; set; }
        public string message { get; set; }
        public bool isError { get; set; }
        public Response() { }
        public Response(int _status, string _message, bool _isError)
        {
            status = _status;
            message = _message;
            isError = _isError;
        }
        public static Response ParseErrorResponse(XmlNode root)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(root.InnerXml);
            XmlNode error = xmlDoc.SelectSingleNode("error");
            Response _response = new Response();
            _response.isError = true;
            _response.status = Convert.ToInt32(error.Attributes["code"].Value);
            _response.message = error.Attributes["msg"].Value;
            return _response;
        }
        public static Response ParseException(Exception ex)
        {
            Response _response = new Response();
            _response.status = 500;
            _response.message = ex.Message;
            _response.isError = true;
            return _response;
        }
    }
}