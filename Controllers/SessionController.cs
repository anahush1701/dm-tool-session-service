using Microsoft.AspNetCore.Mvc;
using SessionService.Context;
using SessionService.Interfaces;
using SessionService.Models;
using SessionService.Models.Joins;

namespace SessionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private ISessionRepository _sessionRepository;
        private SessionServiceDbContext _context;

        public SessionController(ISessionRepository sessionRepository, SessionServiceDbContext context)
        {
            _sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost("create", Name = "createSession")]
        public async Task<ActionResult<Session>> CreateAsync([FromBody] SessionDto sessionDto)
        {
            if (sessionDto == null)
            {
                return BadRequest("Session cannot be null.");
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var session = new Session
                {
                    Id = sessionDto.Id,
                    Name = sessionDto.Name,
                    Description = sessionDto.Description,
                    CampaignId = sessionDto.CampaignId,
                };

                _sessionRepository.AddSession(session);
                await _sessionRepository.SaveChangesAsync();

                foreach (var playerId in sessionDto.PlayerIds)
                {
                    _context.PlayerSessions.Add(new PlayerSession
                    {
                        PlayerId = playerId,
                        SessionId = session.Id,
                    });
                }

                foreach (var locationId in sessionDto.LocationIds)
                {
                    _context.LocationSessions.Add(new LocationSession
                    {
                        LocationId = locationId,
                        SessionId = session.Id
                    });
                }

                foreach (var organizationId in sessionDto.OrganizationIds)
                {
                    _context.OrganizationSessions.Add(new OrganizationSession
                    {
                        OrganizationId = organizationId,
                        SessionId = session.Id
                    });
                }

                foreach (var dungeonMasterId in sessionDto.DmIds)
                {
                    _context.DmSessions.Add(new DmSession
                    {
                        DungeonMasterId = dungeonMasterId,
                        SessionId = session.Id
                    });
                }

                foreach (var npcId in sessionDto.NPCIds)
                {
                    _context.SessionNpcs.Add(new SessionNpc
                    {
                        NpcId = npcId,
                        SessionId = session.Id
                    });
                }

                await _context.SaveChangesAsync();
                transaction.Commit();

                return Ok(session);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return BadRequest($"Error creating session: {ex.Message}");
            }
        }

        [HttpGet("get", Name = "getAllSessions")]
        public async Task<IEnumerable<Session>> GetAsync()
        {
            return await _sessionRepository.GetSessionsAsync();
        }

        [HttpDelete("{id}", Name = "deleteSession")]
        public async Task DeleteAsync(int id)
        {
            _sessionRepository.DeleteSession(id);
            await _sessionRepository.SaveChangesAsync();
        }

        [HttpGet("{id}", Name = "getSession")]
        public async Task<Session> GetAsync(int id)
        {
            return await _sessionRepository.GetSessionAsync(id);
        }
    }
}
