using System;
using System.Collections.Generic;
using System.Drawing;

namespace HS3.Game
{

    public class Game
    {
        public List<Color> GameColors = new List<Color>();
        public List<Color> PickedColors = new List<Color>();
        public int Round = 1;
        public bool IsUserWinning = false;

        private Color GetRandomColor()
        {
            var rnd = new Random();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            return randomColor;
        }

        public void InitGame()
        {
            IsUserWinning = true;
        }

        public List<Color> ShuffleColors()
        {
            for (var i = 0; i < Round; i++)
            {
                GameColors.Add(GetRandomColor());
            }

            return GameColors;
        }

        public void NextRound(List<Color> _pickedColors)
        {
            if (IsUserWinning)
            {
                PickedColors = _pickedColors;

                for (var i = 0; i < GameColors.Count; i++)
                {
                    for (var j = 0; j < PickedColors.Count; j++)
                    {
                        if (GameColors[i] != PickedColors[j])
                            IsUserWinning = false;
                    }
                }

                if (IsUserWinning)
                    Round++;
            }
        }

        public void ClearGame()
        {
            GameColors.Clear();
            PickedColors.Clear();
            Round = 1;
            IsUserWinning = false;
        }
    }
}
