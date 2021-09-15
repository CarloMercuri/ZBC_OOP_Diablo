using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public class WeaponsFactory
    {
        private List<WeaponAttribute> PrimaryAttributes;
        private List<WeaponAttribute> SecondaryAttributes;
        private List<String> Adjectives;
        private List<String> Suffixes;

        public WeaponsFactory()
        {
            FillAttributesLists();
            FillNamesLists();
        }

        /// <summary>
        /// Creates a weapon based on the input
        /// </summary>
        /// <param name="type"></param>
        /// <param name="category"></param>
        /// <param name="quality"></param>
        /// <returns></returns>
        public Weapon CreateWeapon(WeaponType type, WeaponCategory category, WeaponQuality quality)
        {
            Random rand = new Random();
            Weapon weapon = new Weapon(WeaponType.Mace, WeaponCategory.OneHanded, WeaponQuality.Yellow);
            weapon.Name = CreateWeaponName(weapon);
            weapon.Quality = quality;
            weapon.Category = category;
            weapon.Type = type;

            // Create new lists out of the attributes
            List<WeaponAttribute> tempPrimaries = PrimaryAttributes.ToList();
            List<WeaponAttribute> tempSecondaries = SecondaryAttributes.ToList();

            int primariesCount = 0;
            int secondariesCount = 0;

            // Assign the attributes
            switch (quality)
            {
                case WeaponQuality.Blue:
                    weapon.Attributes.Add(PrimaryAttributes[rand.Next(0, PrimaryAttributes.Count)]);
                    weapon.Attributes.Add(SecondaryAttributes[rand.Next(0, SecondaryAttributes.Count)]);
                    break;

                // For yellows and legendaries, always weapon damage and strenght
                case WeaponQuality.Yellow:

                    // 3 primaries in total. 2 always have to be strenght and bonus damage
                    for (int i = 0; i < tempPrimaries.Count; i++)
                    {
                        if (tempPrimaries[i].GetType() == typeof(Strenght) || tempPrimaries[i].GetType() == typeof(BonusDamage))
                        {
                            weapon.Attributes.Add(tempPrimaries[i]);
                            tempPrimaries.RemoveAt(i);
                            primariesCount--;
                        }
                    }

                    // 3rd
                    weapon.Attributes.Add(tempPrimaries[rand.Next(0, tempPrimaries.Count)]);

                    // 1 Secondary
                    weapon.Attributes.Add(SecondaryAttributes[rand.Next(0, SecondaryAttributes.Count)]);
                    break;

                case WeaponQuality.Legendary:
                    primariesCount = 4;
                    secondariesCount = 2;

                    // 4 primaries in total. 2 always have to be strenght and bonus damage
                    for (int i = 0; i < tempPrimaries.Count; i++)
                    {
                        if (tempPrimaries[i].GetType() == typeof(Strenght) || tempPrimaries[i].GetType() == typeof(BonusDamage))
                        {
                            weapon.Attributes.Add(tempPrimaries[i]);
                            tempPrimaries.RemoveAt(i);
                            primariesCount--;
                        }
                    }

                    for (int i = 0; i < primariesCount; i++)
                    {
                        int rnd = rand.Next(0, tempPrimaries.Count);
                        weapon.Attributes.Add(tempPrimaries[rnd]);
                        tempPrimaries.RemoveAt(rnd);
                    }

                    // 2 secondaries
                    for (int i = 0; i < 2; i++)
                    {
                        int rnd = rand.Next(0, tempSecondaries.Count);
                        weapon.Attributes.Add(tempSecondaries[rnd]);
                        tempSecondaries.RemoveAt(rnd);
                    }
                    break;
            }

            // Give the attributes the correct values
            foreach(WeaponAttribute attribute in weapon.Attributes)
            {
                attribute.CalculateAttributeValue(weapon);
            }

            weapon.CalculateWeaponDPS();

            return weapon;



            


        }

        /// <summary>
        /// Creates a randomized name for the weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        private string CreateWeaponName(Weapon weapon)
        {
            Random rand = new Random();
            return $"{Adjectives[rand.Next(0, Adjectives.Count)]} {FormatWeaponTypeName(weapon)} {Suffixes[rand.Next(0, Suffixes.Count)]}";
        }

        /// <summary>
        /// Fixes the names from the enumerators in a readable manner
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        private string FormatWeaponTypeName(Weapon weapon)
        {
            switch (weapon.Type)
            {
                case WeaponType.CeremonialKnife:
                    return "Ceremonial Knife";

                case WeaponType.FistWeapon:
                    return "Fist Weapon";

                case WeaponType.MightyWeapon:
                    return "Mighty Weapon";

                default:
                    return weapon.Type.ToString();

            }
        }

        /// <summary>
        /// Fills the Primary and Secondary attribute lists with the correct attributes
        /// </summary>
        private void FillAttributesLists()
        {
            PrimaryAttributes = new List<WeaponAttribute>();
            SecondaryAttributes = new List<WeaponAttribute>();

            // Get all the classes that implement IWeaponAttribute
            foreach (var type in GetAllTypesDerivingFrom<WeaponAttribute>())
            {
                // Create a new instance of it
                var attribute = (WeaponAttribute)Activator.CreateInstance(type);
                // Separate them in the two lists
                if (attribute.Type == AttributeType.Primary)
                {
                    PrimaryAttributes.Add(attribute);
                }
                else
                {
                    SecondaryAttributes.Add(attribute);
                }

            }

        }

        /// <summary>
        /// Returns a Type list of all the classes that implement the T Interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private IEnumerable<Type> GetAllTypesDerivingFrom<T>()
        {
            return System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsAbstract);
        }

        private void FillNamesLists()
        {
            Adjectives = new List<string>();

            Adjectives.Add("Angelic");
            Adjectives.Add("Arcane");
            Adjectives.Add("Austere");
            Adjectives.Add("Baleful");
            Adjectives.Add("Blessed");
            Adjectives.Add("Blighted");
            Adjectives.Add("Broken");
            Adjectives.Add("Brusque");
            Adjectives.Add("Budget");
            Adjectives.Add("Choleric");
            Adjectives.Add("Cruel");
            Adjectives.Add("Crustaceous");
            Adjectives.Add("Cursed");
            Adjectives.Add("Cynical");
            Adjectives.Add("Defiled");
            Adjectives.Add("Demonic");
            Adjectives.Add("Despairing");
            Adjectives.Add("Divine");
            Adjectives.Add("Doomed");
            Adjectives.Add("Eternal");
            Adjectives.Add("Evil");
            Adjectives.Add("Fanciful");
            Adjectives.Add("Feathered");
            Adjectives.Add("Feline");

            Suffixes = new List<string>();

            Suffixes.Add("of Allotment");
            Suffixes.Add("of Awakening");
            Suffixes.Add("of Bane");
            Suffixes.Add("of Bludgeoning");
            Suffixes.Add("of Chastity");
            Suffixes.Add("of Delirium");
            Suffixes.Add("of Despair");
            Suffixes.Add("of Divinity");
            Suffixes.Add("of Fortitude");
            Suffixes.Add("of Frugality");
            Suffixes.Add("of Gangrene");
            Suffixes.Add("of Gloaming");
            Suffixes.Add("of Iniquity");
            Suffixes.Add("of Keening");
            Suffixes.Add("of Laceration");
            Suffixes.Add("of Magnificence");
            Suffixes.Add("of Mercy");
            Suffixes.Add("of Pandorum");
            Suffixes.Add("of Piety");
            Suffixes.Add("of Purity");
            Suffixes.Add("of Reaming");
            Suffixes.Add("of Redemption");
            Suffixes.Add("of Sloth");
            Suffixes.Add("of Splendor");
            Suffixes.Add("of Taoism");

        }

        


    }
}
