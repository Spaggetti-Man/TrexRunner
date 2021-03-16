using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TrexRunner.Entities;

namespace TrexRunner.System
{
    public class InputController
    {

        private Trex _trex;

        private KeyboardState _previousKeyboardState;


        public InputController(Trex trex)
        {
            _trex = trex;
        }

        public void ProcessControls(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) && ! _previousKeyboardState.IsKeyDown(Keys.Up)){
                if(_trex.State != TrexState.Jumping)
                {
                    _trex.BeginJump();
                }
            }
            else if (!keyboardState.IsKeyDown(Keys.Up) && _trex.State == TrexState.Jumping)
            {
                _trex.CancelJump();
            }

            _previousKeyboardState = keyboardState;

        }

    }
}
