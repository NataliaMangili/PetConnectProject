using MarketplaceAPI.Dtos;
using MarketplaceAPI.Dtos.Item;
using MarketplaceAPI.Services.Item;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarketplaceController : ControllerBase
{
    private readonly IItemService _service;

    public MarketplaceController(IItemService service) => _service = service;

    [HttpGet("items")]
    public async Task<IActionResult> GetAllItems()
    {
        var items = await _service.GetAllItemsAsync();
        return Ok(items);
    }

    [HttpGet("items/{itemId}")]
    public async Task<IActionResult> GetItemById(Guid itemId)
    {
        var item = await _service.GetItemByIdAsync(itemId);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost("items")]
    public async Task<IActionResult> CreateItem([FromBody] CreateMarketplaceItemDto dto)
    {
        await _service.CreateItemAsync(dto);
        return CreatedAtAction(nameof(GetItemById), new { itemId = dto.OngId }, dto);
    }

    [HttpPut("items/{itemId}")]
    public async Task<IActionResult> UpdateItem(Guid itemId, [FromBody] UpdateMarketplaceItemDto dto)
    {
        await _service.UpdateItemAsync(itemId, dto);
        return NoContent();
    }

    [HttpDelete("items/{itemId}")]
    public async Task<IActionResult> DeleteItem(Guid itemId)
    {
        await _service.DeleteItemAsync(itemId);
        return NoContent();
    }

    [HttpGet("my-items")]
    public async Task<IActionResult> GetMyItems()
    {
        var userId = Guid.Parse("ID");
        var items = await _service.GetItemsByUserAsync(userId);
        return Ok(items);
    }
}
