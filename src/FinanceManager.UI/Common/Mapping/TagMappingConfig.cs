using FinanceManager.Application.Tags.Commands.CreateTag;
using FinanceManager.Application.Tags.Common;
using FinanceManager.UI.Models;
using Mapster;

namespace FinanceManager.UI.Common.Mapping
{
    public class TagMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateTagRequest, CreateTagCommand>();

            config.NewConfig<TagResult, TagResponse>();

        }
    }
}
