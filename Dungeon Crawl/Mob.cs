﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon_Crawl
{
    public class Mob
    {
        public char symbol = '*';
        public string name = "";
        public ConsoleForeground colorFore;
        public ConsoleBackground colorBack;
        public int posX, posY;
        public int ai = 0;
        public int defense = 0;
        public int attack = 0;
        public int health = 0;
        public int maxhealth = 0;

        public static List<Mob> mobList = new List<Mob>();

        public static Mob _mobZombie = new Mob();

        public static void init()
        {
            _mobZombie.name = "Zombie";
            _mobZombie.symbol = 'z';
            _mobZombie.colorFore = ConsoleForeground.DarkGreen;
            _mobZombie.colorBack = ConsoleBackground.Black;
            _mobZombie.health = 5;
            _mobZombie.maxhealth = 5;
            _mobZombie.attack = 3;
            _mobZombie.defense = 0;
            _mobZombie.ai = 0;
        }

        public static void spawnMob(Mob m, int x, int y)
        {
            mobList.Add(((Mob)m.MemberwiseClone()).setPos(x, y));
        }

        public Mob setPos(int x, int y)
        {
            posX = x;
            posY = y;
            return this;
        }

        public void update()
        {
            if (ai == 0)
            {
                if (World.rand.Next(2) == 0)
                {
                    if (Program.renderX < posX && !World.map[posX - 1, posY].solid)
                    {
                        posX--;
                    }
                    if (Program.renderX > posX && !World.map[posX + 1, posY].solid)
                    {
                        posX++;
                    }
                    if (Program.renderY < posY && !World.map[posX, posY - 1].solid)
                    {
                        posY--;
                    }
                    if (Program.renderY > posY && !World.map[posX, posY + 1].solid)
                    {
                        posY++;
                    }
                    while ((Program.renderX == posX && Program.renderY == posY) || World.map[posX, posY].solid)
                    {
                        if (Program.renderX == posX && Program.renderY == posY)
                        {
                            Program.player.hurt(attack, false, "You got attacked for " + attack + " damage!");
                        }
                        posX += 1 - World.rand.Next(3);
                        posY += 1 - World.rand.Next(3);
                    }
                }
            }
        }

        public static List<Mob> getMobsAtPos(int x, int y)
        {
            List<Mob> mobTemp = new List<Mob>();
            foreach (Mob m in mobList)
            {
                if (m.posX == x && m.posY == y)
                {
                    mobTemp.Add(m);
                }
            }
            return mobTemp;
        }

        public static void updateMobs()
        {
            foreach (Mob m in mobList)
            {
                m.update();
            }
        }
    }
}
