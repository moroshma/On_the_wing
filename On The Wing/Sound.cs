using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace On_The_Wing
{
    public class Sound
    {
        public void Enhit()
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
            var path = Path.Combine(exePath, "SoundR\\Enhit.wav");

            SoundPlayer simpleSound = new SoundPlayer(path);
            simpleSound.Play();
        }
        public void Phit()
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
            var path = Path.Combine(exePath, "SoundR\\Phit.wav");

            SoundPlayer simpleSound = new SoundPlayer(path);
            simpleSound.Play();
        }
        public void Pshoot()
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
            var path = Path.Combine(exePath, "SoundR\\Pshoot.wav");

            SoundPlayer simpleSound = new SoundPlayer(path);
            simpleSound.Play();
        }
        public void Motor()
        {

            var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
            var path = Path.Combine(exePath, "SoundR\\Motor.wav");

            SoundPlayer motor = new SoundPlayer(path);
            motor.Play();


        }
        public void Heal()
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
            var path = Path.Combine(exePath, "SoundR\\medshot.wav");
            SoundPlayer heal = new SoundPlayer(path);
            heal.Play();


        }

    }
}