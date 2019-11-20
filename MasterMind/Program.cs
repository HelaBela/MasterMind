﻿using System;
using System.Collections.Generic;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            var communication = new ConsoleOperations();

            var validations = new List<IValidation> {new CorrectColorValidator(), new CorrectColorCount()};
            var validator = new InputValidator(validations,communication);

            validator.GetValidUserInput();
            
            //var player = new PlayerInput(communication);
//           player.GetColors();
        }
    }
}