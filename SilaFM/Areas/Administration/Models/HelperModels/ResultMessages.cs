namespace Pras.Web.Areas.Administration.Models.HelperModels
{
    public class ResultMessages
    {
        public string Value { get; set; }
        public MessagesType MessageType { get; set; }
        public ResultsType ResultType { get; set; }
    }

    public enum MessagesType
    {
        Create,
        Edit,
        Save,
        Delete
    }

    public enum ResultsType
    {
        Success,
        Error,
        Warning
    }
}
