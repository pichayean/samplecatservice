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
    public async Task<IActionResult> GetCatsAsync()
    {
        var response = (await _catLogics.GetAllCatsAsync()).Select(cat => new CatResponse(cat)).ToList();
        return Ok(response);
    }

    [HttpGet, Route("GetYoungCats")]
    public async Task<IActionResult> GetYoungCatsAsync()
    {
        var response = (await _catLogics.GetYoungCatsAsync()).Select(cat => new CatResponse(cat)).ToList();
        return Ok(response);
    }

    [HttpGet, Route("GetTeenCats")]
    public async Task<IActionResult> GetTeenCatsAsync()
    {
        var response = (await _catLogics.GetTeenCatsAsync()).Select(cat => new CatResponse(cat)).ToList();
        return Ok(response);
    }

    [HttpGet, Route("GetOldCats")]
    public async Task<IActionResult> GetOldCatsAsync()
    {
        var response = (await _catLogics.GetOldCatsAsync()).Select(cat => new CatResponse(cat)).ToList();
        return Ok(response);
    }

    [HttpGet, Route("GetCat")]
    public async Task<IActionResult> GetCatAsync(Guid id)
    {
        if (Guid.Empty == id)
            return BadRequest();

        var response = new CatResponse(await _catLogics.GetCatByIdAsync(id));
        return Ok(response);
    }

    [HttpPost, Route("CreateCat")]
    public async Task<IActionResult> CreateCatAsync(CreateCatRequest cat)
    {
        var response = new CreateCatResponse(await _catLogics.NewCatAsync(cat.ToEntity()));
        return Ok(response);
    }

    [HttpPut, Route("UpdateCat")]
    public async Task<IActionResult> UpdateCatAsync(CreateCatRequest cat)
    {
        await _catLogics.UpdateCatAsync(cat.ToEntity());

        return Ok(new SuccessResponse()
        {
            Successed = true
        });
    }

    [HttpDelete, Route("RemoveCat")]
    public async Task<IActionResult> RemoveCatAsync(string id)
    {
        if (String.IsNullOrEmpty(id))
            return BadRequest();

        await _catLogics.RemoveCatAsync(id);
        return Ok(new SuccessResponse()
        {
            Successed = true
        });
    }
}
