

using gradtest.Globals;
using Microsoft.AspNetCore.Server.IIS;

namespace gradtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public ContentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var res = await _context.contents.ToListAsync();
            return Ok(res);
        }
        [HttpGet("{type}")]
        //[ProducesResponseType(200,Type = typeof (IEnumerable<>))]
        public async Task<IActionResult> getWithType(string type)
        {
            type = type.ToLower();
            int response = GlobalClass.checkerType(type);
            if (response == -1) return BadRequest("Type is Wrong");
            var videos = await _context.contents.Where(e=>e.Type==response).Select(e => new { e.Url, e.Title, type = type, e.Thumbnail, category = GlobalClass.pam[e.Category] }).ToListAsync();
            if (videos.Count() == 0) return NotFound();
            return Ok(videos);
        }
        
        [HttpGet("{type}/{category}")]
        public async Task<IActionResult> getContentWithTypeCategory(string type,string category)
        {
            type= type.ToLower();
            category= category.ToLower();
            if (GlobalClass.checkerType(type) == -1) return NotFound();
            
            if(GlobalClass.checkerCategory(category) == -1)return BadRequest("category is Wrong");
            
            var ret = await _context.contents.Where(e => e.Type == (GlobalClass.checkerType(type)) && e.Category == GlobalClass.map[category]).Select(e => new { e.Url, e.Title, e.Thumbnail }).ToListAsync();
            return Ok(ret);
            
        }
    }
    
    
}
