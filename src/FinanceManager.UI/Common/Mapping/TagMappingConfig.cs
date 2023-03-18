using FinanceManager.Application.Tags.Commands.CreateTag;
using FinanceManager.Application.Tags.Commands.DeleteTag;
using FinanceManager.Application.Tags.Commands.UpdateTag;
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

            config.NewConfig<UpdateTagRequest, UpdateTagCommand>();

            config.NewConfig<DeleteTagRequest, DeleteTagCommand>();

            config.NewConfig<TagResult, TagResponse>();

        }
    }
}
