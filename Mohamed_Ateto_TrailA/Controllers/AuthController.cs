using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Mohamed_Ateto_TrailA.DTOs.AuthDTOs;
using Mohamed_Ateto_TrailA.Models;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork un;
        private readonly IConfiguration con;
        private readonly IMapper map;

        public AuthController(IUnitOfWork un, IConfiguration con, IMapper map)
        {
            this.un = un;
            this.con = con;
            this.map = map;
        }



        [HttpPost("Register")]
        //[Authorize(Roles = "Candidate")]
        //[Authorize(Roles = "Employer")]
        public async Task<IActionResult> Register(RegisterDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Invalid Data");

            if (DTO.Role == "Admin")
                return BadRequest("Can't register with admin role");

            var item = await un.AuthRepo.GetUserByEmail(DTO.Email);
            if(item != null)
                return BadRequest("Already Exist");


            var Entity = map.Map<User>(DTO);

            await un.AuthRepo.Create(Entity);
            await un.CompleteAsync();

            return Ok("Created Succefully");


        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Invalid Data");

            var item = await un.AuthRepo.GetUserByEmail(DTO.Email);

            if (item.Password != DTO.Password)
                return BadRequest("Password Deosn't Match");



            var token = GenerateToken(item);
        

            return Ok(token);


        }





        private string GenerateToken(User user)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(con["JWT:Key"]));

            var creds = new SigningCredentials(Key,SecurityAlgorithms.HmacSha256);

            var Claims = new List<Claim>()
            {

                new Claim(ClaimTypes.NameIdentifier , user.id.ToString()),
                new Claim(ClaimTypes.Name , user.FullName),
                new Claim(ClaimTypes.Role , user.Role)

            };


            var toke = new JwtSecurityToken(
                issuer : con["JWT:Issuer"],
                audience : con["JWT:Audience"],
                claims : Claims,
                signingCredentials : creds,
                expires : DateTime.Now.AddHours(1)
                

                );

            return new JwtSecurityTokenHandler().WriteToken(toke); 
        }
    }
}
