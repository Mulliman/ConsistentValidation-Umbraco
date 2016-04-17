using ConsistentValidation.Messages;
using ConsistentValidation.Rules;
using Umbraco.Web;

namespace ConsistentValidation.Umb.Messages
{
    public class UmbracoMessageProvider : IMessageProvider
    {
        private readonly UmbracoHelper _helper;
        private readonly string _messagesRootPath;

        public UmbracoMessageProvider(string messagesRootPath)
        {
            _helper = new UmbracoHelper(UmbracoContext.Current);

            _messagesRootPath = messagesRootPath;
        }

        public string GetMessageFor(IValidationRuleData ruleData)
        {
            var path = _messagesRootPath.TrimEnd('/') + ruleData.MessageId;

            var node = _helper.ContentSingleAtXPath(path);

            return node.Message;
        }
    }
}