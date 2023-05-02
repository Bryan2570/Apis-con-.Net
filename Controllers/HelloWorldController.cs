using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{ 
    IHelloWorldService helloWorldService;
    
    TareasContext dbcontext;
    
    public HelloWorldController(IHelloWorldService helloWorld, TareasContext db)
    {
        helloWorldService = helloWorld;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }

    //metodo para comprobar que DB esta creada
    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDataBase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok();
    }



}