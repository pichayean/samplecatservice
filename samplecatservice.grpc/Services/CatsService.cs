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

    public override Task<CatsReply> GetCats(EmptyRequest request, ServerCallContext context)
    {
        var catsReplay = new CatsReply();
        var cats = _catLogics.GetAllCats().Select(_ => new CatReply
        {
            Id = _.Id.ToString(),
            Name = _.Name,
            Color = _.Color,
            CreatedDate = _.CreatedDate.ToString()
        });
        catsReplay.Cats.AddRange(cats);
        return Task.FromResult(catsReplay);
    }

    public override Task<CatsReply> GetYoungCats(EmptyRequest request, ServerCallContext context)
    {
        var catsReplay = new CatsReply();
        var cats = _catLogics.GetYoungCats().Select(_ => new CatReply
        {
            Id = _.Id.ToString(),
            Name = _.Name,
            Color = _.Color,
            CreatedDate = _.CreatedDate.ToString()
        });
        catsReplay.Cats.AddRange(cats);
        return Task.FromResult(catsReplay);
    }

    public override Task<CatsReply> GetTeenCats(EmptyRequest request, ServerCallContext context)
    {
        var catsReplay = new CatsReply();
        var cats = _catLogics.GetTeenCats().Select(_ => new CatReply
        {
            Id = _.Id.ToString(),
            Name = _.Name,
            Color = _.Color,
            CreatedDate = _.CreatedDate.ToString()
        });
        catsReplay.Cats.AddRange(cats);
        return Task.FromResult(catsReplay);
    }

    public override Task<CatsReply> GetOldCats(EmptyRequest request, ServerCallContext context)
    {
        var catsReplay = new CatsReply();
        var cats = _catLogics.GetOldCats().Select(_ => new CatReply
        {
            Id = _.Id.ToString(),
            Name = _.Name,
            Color = _.Color,
            CreatedDate = _.CreatedDate.ToString()
        });
        catsReplay.Cats.AddRange(cats);
        return Task.FromResult(catsReplay);
    }

    public override Task<CatReply> GetCat(CatIdRequest request, ServerCallContext context)
    {
        var cat = _catLogics.GetCatById(new Guid(request.Id));
        return Task.FromResult(new CatReply()
        {
            Id = cat.Id.ToString(),
            Name = cat.Name,
            Color = cat.Color,
            CreatedDate = cat.CreatedDate.ToString()
        });
    }

    public override Task<CatReply> CreateCat(CreateCatRequest request, ServerCallContext context)
    {
        var cat = _catLogics.NewCat(new CatEntity
        {
            Name = request.Name,
            Color = request.Color,
        });
        return Task.FromResult(new CatReply
        {
            Id = cat.Id.ToString(),
            Name = cat.Name,
            Color = cat.Color,
            CreatedDate = cat.CreatedDate.ToString()
        });
    }

    public override Task<SuccessReply> UpdateCat(UpdateCatRequest request, ServerCallContext context)
    {
        _catLogics.UpdateCat(new CatEntity
        {
            Id = new Guid(request.Id),
            Name = request.Name,
            Color = request.Color,
        });
        return Task.FromResult(new SuccessReply{
            Successed = "true"
        });
    }

    public override Task<SuccessReply> RemoveCat(CatIdRequest request, ServerCallContext context)
    {
        _catLogics.RemoveCat(request.Id);
        return Task.FromResult(new SuccessReply
        {
            Successed = "true"
        });
    }
}
