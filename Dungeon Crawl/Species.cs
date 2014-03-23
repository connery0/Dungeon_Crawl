﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon_Crawl
{
    public class Species
    {
        public BaseStatSet baseStats;
        public Size size;
        public Armor armor;
        public string abbrv = "Hu";
        public string name = "Human";
        public string lore = "";

        //All the species
        public static Species _human = new Species();
        public static Species _highElf = new Species();
        public static Species _woodElf = new Species();
        public static Species _hillOrc = new Species();
        public static Species _mountainDwarf = new Species();
        public static Species _gnome = new Species();
        public static Species _faerie = new Species();
        public static Species _trollGnome = new Species();

        public static Species[] speciesList;
        
        public static void init()
        {
            //All stats should add up to a total of 54

            _human.baseStats = new BaseStatSet(10, 10, 10, 10, 14, 0);
            _human.size = Size.MEDIUM;
            _human.armor = Armor.DEFAULT;
            _human.abbrv = "Hu";
            _human.name = "Human";
            _human.lore = "A race of people who live above the earth";

            _highElf.baseStats = new BaseStatSet(9, 11, 12, 10, 10, 2);
            _highElf.size = Size.MEDIUM;
            _highElf.armor = Armor.DEFAULT;
            _highElf.abbrv = "He";
            _highElf.name = "High Elf";
            _highElf.lore = "Proud denizens with powerful magic";

            _woodElf.baseStats = new BaseStatSet(7, 13, 11, 11, 11, 1);
            _woodElf.size = Size.MEDIUM;
            _woodElf.armor = Armor.DEFAULT;
            _woodElf.abbrv = "We";
            _woodElf.name = "Wood Elf";
            _woodElf.lore = "Masters of the forest that are in tune with nature";

            _hillOrc.baseStats = new BaseStatSet(14, 10, 7, 6, 17, 0);
            _hillOrc.size = Size.LARGE;
            _hillOrc.armor = Armor.DEFAULT;
            _hillOrc.abbrv = "Ho";
            _hillOrc.name = "Hill Orc";

            _mountainDwarf.baseStats = new BaseStatSet(13, 12, 7, 8, 14, 0);
            _mountainDwarf.size = Size.SMALL;
            _mountainDwarf.armor = Armor.DEFAULT;
            _mountainDwarf.abbrv = "Md";
            _mountainDwarf.name = "Mountain Dwarf";

            _gnome.baseStats = new BaseStatSet(8, 14, 12, 9, 11, 1);
            _gnome.size = Size.TINY;
            _gnome.armor = Armor.DEFAULT;
            _gnome.abbrv = "Gn";
            _gnome.name = "Gnome";

            _faerie.baseStats = new BaseStatSet(5, 6, 10, 10, 17, 6);
            _faerie.size = Size.TINY;
            _faerie.armor = Armor.NONE;
            _faerie.abbrv = "Fa";
            _faerie.name = "Faerie";

            _trollGnome.baseStats = new BaseStatSet(10, 10, 8, 9, 16, 1);
            _trollGnome.size = Size.SMALL;
            _trollGnome.armor = Armor.DEFAULT;
            _trollGnome.abbrv = "Tg";
            _trollGnome.name = "Troll Gnome";

            //All accessible species
            //If a species is not in this list, it's not accessible by the player
            speciesList = new Species[] {
                _human,
                _highElf,
                _woodElf,
                _hillOrc,
                _mountainDwarf,
                _gnome,
                _trollGnome,
                _faerie
            };
        }

        public static void drawSpecies(Species s)
        {
            Console.WriteLine(s.name + " (" + s.abbrv + ")");
        }
        public static void drawAllSpecies()
        {
            for (int x = 0; x < speciesList.Length; x++)
            {
                Console.SetCursorPosition(1, x + 1);
                if (Program.selectedSpecies == x)
                {
                    ConsoleEx.TextColor(ConsoleForeground.Magenta, ConsoleBackground.Yellow);
                    drawSpecies(speciesList[x]);
                }
                else
                {
                    ConsoleEx.TextColor(ConsoleForeground.LightGray, ConsoleBackground.Black);
                    drawSpecies(speciesList[x]);
                }
            }
            ConsoleEx.TextColor(ConsoleForeground.LightGray, ConsoleBackground.Black);
        }
        public static void drawAllSpecies(int y)
        {
            for (int x = 0; x < speciesList.Length; x++)
            {
                Console.SetCursorPosition(1, y + x + 1);
                drawSpecies(speciesList[x]);
            }
            //ConsoleEx.TextColor(ConsoleForeground.LightGray, ConsoleBackground.Black);
        }
    }
}
