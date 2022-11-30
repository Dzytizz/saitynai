using Microsoft.AspNetCore.Identity;
using saitynai_server.Auth;
using saitynai_server.Auth.Model;
using saitynai_server.Controllers;

namespace saitynai_server.Helpers
{
    public class AuthDbSeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        private readonly IGamesRepository _gamesRepository;

        public AuthDbSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IGamesRepository gamesRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            _gamesRepository = gamesRepository;
        }

        public async Task SeedAsync()
        {
            await AddDefaultRoles();
            await AddAdminUser();
            await AddGames();
        }

        private async Task AddDefaultRoles()
        {
            foreach (var role in Roles.All)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task AddAdminUser()
        {
            var newAdminUser = new User
            {
                UserName = "admin",
                Email = "admin@email.com"
            };

            var existingAdminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);
            if (existingAdminUser == null)
            {
                var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "password123");
                if (createAdminUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newAdminUser, Roles.Admin);
                }
            }
        }

        private async Task AddGames()
        {
            Game[] games = {
                new Game
                {
                    Title = "Sagrada",
                    Description = "Šiame žaidime tapsite vitražų meistrais ir varžysitės dėl didžiausio šedevro kūrėjo titulo.",
                    MinPlayers = 2,
                    MaxPlayers = 4,
                    Rules = "Žaidimo eigoje  rinksite kauliukus ir iš jų dėliosite savo vitražą. Ne visi kauliukai dera tarpusavyje: panašių atspalvių kauliukai negali būti greta vienas kito, turimos žaidimo lentelės taip pat įveda papildomų apribojimų, kuriuos galite apeiti panaudodami specialius įrankius.",
                    Difficulty = 3,
                    Photos = FileManagementController._defaultImage
                },
                new Game
                {
                    Title = "Uno",
                    Description = "Vienas populiariausių kortų žaidimų",
                    MinPlayers = 2,
                    MaxPlayers = 10,
                    Rules = "Paeiliui, žaidėjai bando padėti kortą sutampančią pagal skaičių arba spalvą su korta ant stalo viduryje esančios kortų krūvos viršaus. Jeigu jie negali kortos dėti, jie turi traukti naują kortą, ir jeigu vis dar negali, turi praleisti ėjimą.",
                    Difficulty = 2,
                    Photos = FileManagementController._defaultImage
                },
                new Game
                {
                    Title = "Monopoly",
                    Description = "Klasikinis greitų sandorių nekilnojamojo turto prekybos žaidimas, kuriame laimi turtingiausias.",
                    MinPlayers = 2,
                    MaxPlayers = 8,
                    Rules = "Išsirink labiausiai patinkančią „Monopolio“ figūrėlę, ridenk kauliukus ir judėk žaidimo lenta, stengdamasis įsigyti kuo daugiau nuosavybės!",
                    Difficulty = 4,
                    Photos = FileManagementController._defaultImage
                },
                new Game
                {
                    Title = "Jungle Speed",
                    Description = "Reakcijos stalo žaidimas Jungle Speed su medine figūrėle.",
                    MinPlayers = 2,
                    MaxPlayers = 10,
                    Rules = "Žaidėjai žaidžia su įvairių spalvų kortelėmis, turinčiomis simbolius. Jei žaidimo lentoje padėtų kortelių simboliai sutampa, žaidėjai turi kuo greičiau žaimti medinę figūrėlę.",
                    Difficulty = 2,
                    Photos = FileManagementController._defaultImage
                }
            };

            var existingGames = _gamesRepository.GetAllAsync().Result;

            foreach(Game game in games)
            {
                if (!existingGames.Any(g => g.Title.Equals(game.Title) && g.Description.Equals(game.Description)))
                {
                    await _gamesRepository.CreateAsync(game);
                }
            }
        }
    }
}
