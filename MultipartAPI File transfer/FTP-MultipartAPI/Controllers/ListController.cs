using FTP_MultipartAPI.Implementation;
using FTP_MultipartAPI.Interface;
using FTP_MultipartAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FTP_MultipartAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListController : Controller
    {
        //Class_Users opt = new Class_Users();
        
        public readonly IUserOperation opt;
        public ListController(IUserOperation opt)
        {
            this.opt = opt;

        }
        
        

        Return obj;

        [HttpGet("Get List of all record")]
        public IActionResult Get()
        {
            Console.WriteLine("get function");
            try
            {
                var result = opt.getitem();
                if (result.Count > 0)
                {
                    obj = new Return()
                    {
                        message = "success",
                        return_code = 123,

                    };
                    obj.data = result;

                    return StatusCode(10, result);
                }
                else
                {
                    obj = new Return()
                    {
                        message = "empty list",

                    };
                    return StatusCode(200, obj);
                }

            }
            catch (Exception ex)
            {
                obj = new Return()
                {
                    message = "error",
                    return_code = 000
                };
                return StatusCode(000, obj);
            }
        }

        [HttpPost("Add record")]
        public IActionResult Post(Users objec)
        {
            try
            {
                opt.additem(objec);

                obj = new Return()
                {
                    message = $"successfully added {objec.Name}",
                    return_code = 2323
                };

                return StatusCode(200, obj);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new Return()
                {
                    message = "cant add details:(",
                    return_code = 501

                });
            }
        }

        [HttpDelete("Delete record")]
        public IActionResult Delete(int id, string name)
        {
            try
            {

            opt.removeitem(id, name);
            obj = new Return()
            {

                message = $"Successfully deleted {name}",
                return_code = 3232
            };
            return StatusCode(200, obj);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new Return() { message = "failed", return_code = 123 });
            }
        }

        [HttpPatch("Update record")]
        public IActionResult Update(Users objec)
        {
            try
            {
                int n = opt.updateitem(objec);
                if (n == 1)
                    {
                    obj = new Return()
                    {
                        message = $"Successfully deleted {objec.Name}",
                        return_code = 3232
                    };
                    return StatusCode(200, obj);
                }
                else
                {
                    return StatusCode(500, new Return() { message = "failure", return_code = 213 });
                }
            }
            catch {

                return StatusCode(500, new Return() { message = "failed", return_code = 123 });
            }

        }


    }
}
