namespace Server.Database;

using Microsoft.EntityFrameworkCore;

public class GuildService
{
    public readonly AnalyticsContext _context;

    public GuildService(AnalyticsContext analyticsContext)
    {
        _context = analyticsContext;
    }

    public async Task<Guild?> GetGuild(string guildId)
    {
        return await _context.Guilds.Where(g => g.GuildId == guildId).SingleOrDefaultAsync();
    }

    public async Task<Guild> UpsertGuild(Guild guild)
    {
        var exists = await _context.Guilds.AnyAsync(g => g.GuildId == guild.GuildId);

        if (exists)
        {
            _context.Guilds.Update(guild);
        }
    }

    //public async Task<UpdateGuildCommand> UpdateGuild(string guildId) { }
}

//public class RecipeService
//{
//    public async Task<int> CreateRecipe(CreateRecipeCommand cmd)
//    {
//        var recipe = cmd.ToRecipe();
//        _context.Add(recipe);
//        await _context.SaveChangesAsync();
//        return recipe.RecipeId;
//    }

//    /// <summary>
//    /// Updates an existing recipe
//    /// </summary>
//    /// <param name="cmd"></param>
//    /// <returns>The id of the new recipe</returns>
//    public async Task UpdateRecipe(UpdateRecipeCommand cmd)
//    {
//        var recipe = await _context.Recipes.FindAsync(cmd.Id);
//        if (recipe == null)
//        {
//            throw new Exception("Unable to find the recipe");
//        }
//        if (recipe.IsDeleted)
//        {
//            throw new Exception("Unable to update a deleted recipe");
//        }

//        cmd.UpdateRecipe(recipe);
//        await _context.SaveChangesAsync();
//    }

//    /// <summary>
//    /// Marks an existing recipe as deleted if it exists
//    /// </summary>
//    /// <param name="cmd"></param>
//    /// <returns>The id of the new recipe</returns>
//    public async Task DeleteRecipe(int recipeId)
//    {
//        var recipe = await _context.Recipes.FindAsync(recipeId);
//        if (recipe is not null)
//        {
//            recipe.IsDeleted = true;
//            await _context.SaveChangesAsync();
//        }
//    }
//}
