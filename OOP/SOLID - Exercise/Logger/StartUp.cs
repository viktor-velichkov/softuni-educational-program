﻿using CreateLogger.Common;
using CreateLogger.Core;
using CreateLogger.Enumerations;
using CreateLogger.Factories;
using CreateLogger.IOManagemenet;
using CreateLogger.IOManagemenet.Contracts;
using CreateLogger.Models;
using CreateLogger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreateLogger
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPathManager pathManager = new PathManager("logs", "logs.txt");
            IFile file = new LogFile(pathManager);

            ILogger logger = SetUpLogger(n, reader, writer, file, layoutFactory, appenderFactory);
            IEngine engine = new Engine(logger, reader, writer);
            engine.Run();
        }
        private static ILogger SetUpLogger(int appenderCnt, IReader reader, IWriter writer, IFile file, LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
            ICollection<IAppender> appenders = new HashSet<IAppender>();
            for (int i = 0; i < appenderCnt; i++)
            {
                string[] appendersArgs = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];
                bool hasError = false;
                Level level = ParseLevel(appendersArgs, writer, ref hasError);
                if (hasError)
                {
                    continue;
                }
                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreateAppender(appenderType, layout, level, file);
                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {
                    writer.Write(ioe.Message);
                }

            }
            ILogger logger = new Logger(appenders);
            return logger;
        }
        private static Level ParseLevel(string[] levelStr, IWriter writer, ref bool hasError)
        {
            Level appenderLevel = Level.INFO;
            if (levelStr.Length == 3)
            {
                bool isEnumValid = Enum.TryParse(typeof(Level), levelStr[2], true, out object enumParsed);
                if (!isEnumValid)
                {
                    writer.WriteLine(GlobalConstants.InvalidLevelType);
                    hasError = true;
                }
                appenderLevel = (Level)enumParsed;
            }
            return appenderLevel;
        }
    }
}
