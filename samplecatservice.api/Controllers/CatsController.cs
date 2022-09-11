using Microsoft.AspNetCore.Mvc;
using samplecatservice.api.Models;
using samplecatservice.Logics;

namespace samplecatservice.api.Controllers;

[ApiController]
[Route("[controller]")]
public class CatsController : ControllerBase
{
    private readonly ICatLogics _catLogics;

    public CatsController(ICatLogics catLogics)
    {
        _catLogics = catLogics;
    }

    [HttpGet, Route("GetCats")]
    public IActionResult GetCats()
    {
        var response = _catLogics.GetAllCats().Select(cat => new CatResponse(cat)).ToList();
        return Ok(response);
    }

    [HttpGet, Route("GetYoungCats")]
    public IActionResult GetYoungCats()
    {
        var response = _catLogics.GetYoungCats().Select(cat => new CatResponse(cat)).ToList();
        return Ok(response);
    }

    [HttpGet, Route("GetTeenCats")]
    public IActionResult GetTeenCats()
    {
        var response = _catLogics.GetTeenCats().Select(cat => new CatResponse(cat)).ToList();
        return Ok(response);
    }

    [HttpGet, Route("GetOldCats")]
    public IActionResult GetOldCats()
    {
        var response = _catLogics.GetOldCats().Select(cat => new CatResponse(cat)).ToList();
        return Ok(response);
    }

    [HttpGet, Route("GetCat")]
    public IActionResult GetCat(Guid id)
    {
        if (Guid.Empty == id)
            return BadRequest();

        var response = new CatResponse(_catLogics.GetCatById(id));
        return Ok(response);
    }

    [HttpPost, Route("CreateCat")]
    public IActionResult CreateCat(CreateCatRequest cat)
    {
        var response = new CreateCatResponse(_catLogics.NewCat(cat.ToEntity()));
        return Ok(response);
    }

    [HttpPut, Route("UpdateCat")]
    public IActionResult UpdateCat(CreateCatRequest cat)
    {
        _catLogics.UpdateCat(cat.ToEntity());

        return Ok(new SuccessResponse()
        {
            Successed = true
        });
    }

    [HttpDelete, Route("RemoveCat")]
    public IActionResult RemoveCat(string id)
    {
        if (String.IsNullOrEmpty(id))
            return BadRequest();

        _catLogics.RemoveCat(id);
        return Ok(new SuccessResponse()
        {
            Successed = true
        });
    }
}
