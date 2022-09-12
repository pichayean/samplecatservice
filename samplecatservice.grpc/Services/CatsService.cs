using Grpc.Core;
using samplecatservice.Entities;
using samplecatservice.Logics;

namespace samplecatservice.grpc.Services;

public class CatsService : Cats.CatsBase
{
    private readonly ILogger<CatsService> _logger;
    private readonly ICatLogics _catLogics;
    public CatsService(ILogger<CatsService> logger, ICatLogics catLogics)
    {
        _logger = logger;
        _catLogics = catLogics;
    }

    public override async Task<CatsReply> GetCats(EmptyRequest request, ServerCallContext context)
    {
        var catsReplay = new CatsReply();
        var cats = (await _catLogics.GetAllCatsAsync()).Select(_ => new CatReply
        {
            Id = _.Id.ToString(),
            Name = _.Name,
            Color = _.Color,
            CreatedDate = _.CreatedDate.ToString()
        });
        catsReplay.Cats.AddRange(cats);
        return catsReplay;
    }

    public override async Task<CatsReply> GetYoungCats(EmptyRequest request, ServerCallContext context)
    {
        var catsReplay = new CatsReply();
        var cats = (await _catLogics.GetYoungCatsAsync()).Select(_ => new CatReply
        {
            Id = _.Id.ToString(),
            Name = _.Name,
            Color = _.Color,
            CreatedDate = _.CreatedDate.ToString()
        });
        catsReplay.Cats.AddRange(cats);
        return catsReplay;
    }

    public override async Task<CatsReply> GetTeenCats(EmptyRequest request, ServerCallContext context)
    {
        var catsReplay = new CatsReply();
        var cats = (await _catLogics.GetTeenCatsAsync()).Select(_ => new CatReply
        {
            Id = _.Id.ToString(),
            Name = _.Name,
            Color = _.Color,
            CreatedDate = _.CreatedDate.ToString()
        });
        catsReplay.Cats.AddRange(cats);
        return catsReplay;
    }

    public override async Task<CatsReply> GetOldCats(EmptyRequest request, ServerCallContext context)
    {
        var catsReplay = new CatsReply();
        var cats = (await _catLogics.GetOldCatsAsync()).Select(_ => new CatReply
        {
            Id = _.Id.ToString(),
            Name = _.Name,
            Color = _.Color,
            CreatedDate = _.CreatedDate.ToString()
        });
        catsReplay.Cats.AddRange(cats);
        return catsReplay;
    }

    public override async Task<CatReply> GetCat(CatIdRequest request, ServerCallContext context)
    {
        var cat = await _catLogics.GetCatByIdAsync(new Guid(request.Id));
        return new CatReply()
        {
            Id = cat.Id.ToString(),
            Name = cat.Name,
            Color = cat.Color,
            CreatedDate = cat.CreatedDate.ToString()
        };
    }

    public override async Task<CatReply> CreateCat(CreateCatRequest request, ServerCallContext context)
    {
        var cat = await _catLogics.NewCatAsync(new CatEntity
        {
            Name = request.Name,
            Color = request.Color,
        });
        return new CatReply
        {
            Id = cat.Id.ToString(),
            Name = cat.Name,
            Color = cat.Color,
            CreatedDate = cat.CreatedDate.ToString()
        };
    }

    public override async Task<SuccessReply> UpdateCat(UpdateCatRequest request, ServerCallContext context)
    {
        await _catLogics.UpdateCatAsync(new CatEntity
        {
            Id = new Guid(request.Id),
            Name = request.Name,
            Color = request.Color,
        });
        return new SuccessReply
        {
            Successed = "true"
        };
    }

    public override async Task<SuccessReply> RemoveCat(CatIdRequest request, ServerCallContext context)
    {
        await _catLogics.RemoveCatAsync(request.Id);
        return new SuccessReply
        {
            Successed = "true"
        };
    }
}
