namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Trainer
    {
        private string name;
        private int badges;
        private IList<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int Badges
        {
            get => this.badges;
            private set => this.badges = value;
        }

        public IList<Pokemon> Pokemons
        {
            get => this.pokemons;
            private set => this.pokemons = value;
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
        }

        public void IncreaseBadges()
        {
            this.Badges++;
        }

        public void DecreasePokemonsHealth()
        {
            foreach (var pokemon in this.Pokemons)
            {
                pokemon.DecreaseHealth(10);
            }
        }

        public void RemoveDeathPokemons()
        {
            for (int i = this.Pokemons.Count - 1; i >= 0; i--)
            {
                if (this.Pokemons[i].Health <= 0)
                {
                    this.Pokemons.RemoveAt(i);
                }
            }
        }
    }
}
