using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;


public class SSS : PhysicsGame
{
    Image PuuKuva = LoadImage("tree");
    Image LattiaKuva = LoadImage("Snowtile");

    PhysicsObject pelaaja1;
    AssaultRifle pelaajan1Ase;
    
    public override void Begin()
    {
        
        TileMap kentta = TileMap.FromLevelAsset("kentta1");

        kentta.SetTileMethod('h', LuoTalo);
        kentta.SetTileMethod('f', LuoLattia);
        kentta.SetTileMethod('t', LuoPuu);


        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");

        kentta.Execute(16, 16);
        kentta.Optimize('f');
        
       
        pelaaja1 = new PhysicsObject(40, 40);
        Add(pelaaja1);
        Camera.Follow(pelaaja1);
       
        

        Keyboard.Listen(Key.A, ButtonState.Down, LiikutaPelaajaa, null, new Vector(-150, 0));
        Keyboard.Listen(Key.D, ButtonState.Down, LiikutaPelaajaa, null, new Vector(150,0));
        Keyboard.Listen(Key.W, ButtonState.Down, LiikutaPelaajaa, null, new Vector(0, 150));
        Keyboard.Listen(Key.S, ButtonState.Down, LiikutaPelaajaa, null, new Vector(0, -150));

        pelaajan1Ase = new AssaultRifle(30, 10);
        pelaajan1Ase.Ammo.Value = 1000;
        pelaaja1.Add(pelaajan1Ase);
    }
    void LiikutaPelaajaa(Vector vektori)
    {
        pelaaja1.Push(vektori);
    }

    void LuoTalo(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject Talo = PhysicsObject.CreateStaticObject(630, 450);
        Talo.Position = paikka;
        Talo.Color = Color.Red;
        Add(Talo, -1);
    }
    void LuoLattia(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject Lattia = PhysicsObject.CreateStaticObject(1024, 1024);
        Lattia.Position = paikka;
        Lattia.Color = Color.LightGray;

        Add(Lattia, -1);
    }
    void LuoPuu(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject Puu = PhysicsObject.CreateStaticObject(206, 206);
        Puu.Position = paikka;
        Puu.Color = Color.Green;
        Puu.Image = PuuKuva;
        Add(Puu);
    }
}






