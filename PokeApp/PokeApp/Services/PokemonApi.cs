using System;
using System.Collections.Generic;
using System.Diagnostics;
using Dasync.Collections;
using PokeApiNet;

namespace PokeApp.Services
{
    public interface IPokemonApi
    {
        IAsyncEnumerable<PokemonItem> GetPokemonAsync(int offset, int limit);
    }

    internal class PokemonApi : IPokemonApi
    {
        private readonly PokeApiClient pokeApiClient;

        public PokemonApi()
        {
            pokeApiClient = new PokeApiClient();
        }

        public IAsyncEnumerable<PokemonItem> GetPokemonAsync(int offset, int limit)
        {
            return new AsyncEnumerable<PokemonItem>(async yield =>
            {
                try
                {
                    var page = await pokeApiClient.GetNamedResourcePageAsync<Pokemon>(limit, offset);

                    foreach (var result in page.Results)
                    {
                        var pokemon = await pokeApiClient.GetResourceAsync<Pokemon>(result.Name);

                        await yield.ReturnAsync(new PokemonItem
                        {
                            Id = pokemon.Id,
                            Name = pokemon.Name,
                            DefaultImageUrl = pokemon.Sprites.FrontDefault,
                            ShinyImageUrl = pokemon.Sprites.FrontShiny
                        });
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to get data: {ex.Message}");
                    throw;
                }
            });
        }
    }

    public class PokemonItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DefaultImageUrl { get; set; }
        public string ShinyImageUrl { get; set; }
    }
}
