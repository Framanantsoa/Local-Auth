using DTO;
using Microsoft.AspNetCore.Mvc;
using Models;
using Utils;

namespace Services;

[ApiController]
[Route("/api/auths")]
public class AuthController : ControllerBase
{
    private readonly IAuthService service;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService svc, ILogger<AuthController> logger) {
        service = svc; _logger = logger;
    }


    [HttpPost("register")]
    public async Task<IActionResult> registerUser([FromBody] RegisterDto dto) {
        if(!ModelState.IsValid) {
            return UnprocessableEntity(ResponseApi.Fail(
                "Erreur de validation", ModelState
            ));
        }
        Utilisateur user = await service.registerUser(dto);

        return Ok(ResponseApi.Ok(
            "Utilisateur ajouté avec succès",
            new { id = user.id, nom = user.nom }
        ));
    }


    [HttpPost("signin")]
    public async Task<IActionResult> logUser([FromBody] LoginDto dto) {
        if(!ModelState.IsValid) {
            return UnprocessableEntity(ResponseApi.Fail(
                "Erreur de validation", ModelState
            ));
        }

        try {
            string token = await service.logUser(dto);

            return Ok(ResponseApi.Ok(
                "Connexion réussie", token
            ));
        }
        catch(ArgumentException e) {
            return BadRequest(ResponseApi.Fail(e.Message, null));
        }
    }


    [HttpPost("logout")]
    public async Task<IActionResult> logoutUser([FromBody] string token) {
        try {
            await service.logoutUser(token);
            return Ok(ResponseApi.Ok("Déconnexion réussie", null));
        }
        catch(ArgumentException e) {
            return BadRequest(ResponseApi.Fail(e.Message, null));
        }
    }


    [HttpPost("check")]
    public async Task<IActionResult> isAuthenticated([FromBody] string token) {
        bool authenticated = await service.isAuthenticated(token);
        
        if(authenticated) {
            return Ok(ResponseApi.Ok("Connecté", null));
        }
        return Unauthorized(ResponseApi.Fail("Non connecté", null));
    }


    [HttpPost("expand")]
    public async Task<IActionResult> refreshToken([FromBody] string token) {
        try {
            await service.refreshToken(token);

            return Ok(ResponseApi.Ok(
                "Session prolongée avec succès", null
            ));
        }
        catch(ArgumentException e) {
            return BadRequest(ResponseApi.Fail(e.Message, null));
        }
    }


    [HttpPost("profile")]
    public async Task<IActionResult> getProfile([FromBody] string token) {
        try {
            PersoInfoDto infos = await service.getPersonnalInformations(token);

            return Ok(ResponseApi.Ok(
                "Profil trouvé avec succès", infos
            ));
        }
        catch(ArgumentException e) {
            return BadRequest(ResponseApi.Fail(e.Message, null));
        }
    }


    [HttpPost("profile/update")]
    public async Task<IActionResult> updateProfile([FromBody] UpdateDto updateDto) {
        _logger.LogInformation("ID = blabla");
        
        try {
            string token = updateDto.token;
            InfoUpdateDto infos = updateDto.profil;

            var user = await service.getUserByToken(updateDto.token);
            await service.updateUserInformations(token, infos);

            return Ok(ResponseApi.Ok(
                "Profil mis à jour avec succès", new { email=infos.email }
            ));
        }
        catch(ArgumentException e) {
            return BadRequest(ResponseApi.Fail(e.Message, null));
        }
    }
}
