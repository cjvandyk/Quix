﻿#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060, IDE0079 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args, Remove unnecessary suppression)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// </summary>

using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class Constants
    {
        /// <summary>
        /// String array of lorem ipsum text.
        /// </summary>
        public readonly static string[] LoremIpsum =
        {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer aliquam arcu rhoncus erat consectetur, quis rutrum augue tincidunt. Suspendisse elit ipsum, lobortis lobortis tellus eu, vulputate fringilla lorem. Cras molestie nibh sed turpis dapibus sollicitudin ut a nulla. Suspendisse blandit suscipit egestas. Nunc et ante mattis nulla vehicula rhoncus. Vivamus commodo nunc id ultricies accumsan. Mauris vitae ante ut justo venenatis tempus.",
            "Nunc posuere, nisi eu convallis convallis, quam urna sagittis ipsum, et tempor ante libero ac ex. Aenean lacus mi, blandit non eros luctus, ultrices consectetur nunc. Vivamus suscipit justo odio, a porta massa posuere ac. Aenean varius leo non ipsum porttitor eleifend. Phasellus accumsan ultrices massa et finibus. Nunc vestibulum augue ut bibendum facilisis. Donec est massa, lobortis quis molestie at, placerat a neque. Donec quis bibendum leo. Pellentesque ultricies ac odio id pharetra. Nulla enim massa, lacinia nec nunc nec, egestas pulvinar odio. Sed pulvinar molestie justo, eu hendrerit nunc blandit eu. Suspendisse et sapien quis ipsum scelerisque rutrum.",
            "Mauris eget convallis lorem, rutrum venenatis risus. Cras turpis risus, convallis nec lectus id, blandit varius ante. Morbi id turpis vel neque gravida consequat in elementum tellus. Fusce venenatis ex eget quam tincidunt varius. Mauris non mauris est. Vestibulum eget pharetra risus, sit amet accumsan elit. Etiam rhoncus tristique mauris. Ut convallis dignissim dictum. Vivamus dolor augue, vulputate a consequat ut, euismod finibus mi. Morbi sit amet pellentesque lectus.",
            "Nullam mattis cursus lorem ut venenatis. Praesent et sapien at tellus feugiat varius non eget orci. Maecenas sodales orci vitae rhoncus posuere. Aliquam erat volutpat. Nullam nulla sapien, faucibus sit amet porttitor vitae, fermentum ut orci. Etiam accumsan lacus quis tortor posuere, vitae tristique urna porta. Proin urna velit, lobortis ut gravida sit amet, iaculis vitae tellus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam porttitor metus eu finibus malesuada. Vivamus lobortis mauris id erat condimentum, ac laoreet mauris tristique. Fusce sit amet arcu purus. Donec quam enim, ultrices luctus nisi eget, vestibulum porta enim. Fusce sed iaculis metus, nec fermentum nisl. Pellentesque in condimentum risus, a fringilla turpis.",
            "In in interdum lectus. Quisque aliquet sem ac ante tincidunt, at sodales libero mollis. In suscipit felis vitae mauris ultricies, at commodo magna hendrerit. Pellentesque convallis, justo a fermentum dapibus, augue quam tempor lectus, ac dignissim magna tellus luctus odio. Morbi sed vestibulum diam. Proin sodales urna vitae ex cursus volutpat. Cras dapibus quam velit, eu ultrices est rhoncus id. Sed sit amet ligula eget nisl tempus iaculis. Donec et lacus a tellus volutpat suscipit sed in nisi. Vivamus placerat semper ex et pellentesque.",
            "Sed pulvinar felis ut ipsum feugiat sollicitudin. Mauris ut nisi vel nibh vestibulum pellentesque. Sed dignissim rhoncus mattis. Duis in placerat magna. Duis interdum lorem sed consequat molestie. Proin maximus dolor sit amet placerat pellentesque. Proin porttitor magna at ante vestibulum, sed egestas tortor maximus. Vestibulum nec tristique neque, eget euismod mauris. Aliquam non enim metus. Curabitur iaculis tellus dui, id tempor metus fringilla id. Phasellus ante tellus, egestas eu risus in, lacinia molestie purus. Fusce ultricies vehicula massa a vehicula. Proin at magna quis nunc faucibus ultricies eget eu orci. Aenean cursus lorem eros, in tempor magna mattis sed. Donec ac bibendum risus. Phasellus urna ante, sodales at leo eu, lobortis faucibus risus.",
            "Cras aliquam metus vel purus suscipit vehicula. Curabitur dignissim velit eget ante mollis sollicitudin. Sed id lorem nec mi varius aliquet at nec lorem. Nullam vel lorem libero. Mauris rhoncus dolor non facilisis feugiat. Suspendisse cursus vel elit non porta. Duis sodales vel nisl non pharetra.",
            "Integer mi libero, tincidunt id erat ut, sollicitudin laoreet est. Aliquam non lectus luctus, placerat ligula semper, vestibulum arcu. Fusce ut lobortis quam. Nunc et mollis lectus. Curabitur condimentum ac nisi quis congue. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nam porttitor elit eget elit finibus, sed sagittis tortor aliquet. Sed et accumsan dui, lobortis luctus eros. Cras a dolor turpis. Aenean mollis, nulla sit amet eleifend cursus, arcu erat dignissim neque, non egestas ligula metus at purus. Etiam hendrerit magna ut vehicula sodales. Duis dictum lorem in magna bibendum eleifend. Cras sed diam ut sem pretium vestibulum sed non nibh. Morbi finibus enim nec lacus aliquet, id convallis sapien vulputate.",
            "In hac habitasse platea dictumst. Vivamus sit amet ornare magna. Curabitur sollicitudin viverra nibh, sit amet tempor nisl dictum nec. Integer in auctor sem. Phasellus accumsan ante mollis dui feugiat, non semper augue posuere. Cras ac faucibus nulla, id elementum ante. Nulla ipsum felis, semper id eleifend in, placerat nec ipsum. Nunc ut leo tincidunt, facilisis leo egestas, sollicitudin lacus. Curabitur at ex eget libero convallis volutpat.",
            "Nulla facilisi. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque eu tristique lacus, sed porta nisl. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum libero neque, faucibus sed condimentum sed, aliquet vitae massa. Sed dignissim a velit tempus feugiat. Etiam sollicitudin, neque sit amet posuere semper, enim enim facilisis quam, ac sollicitudin lectus purus ut urna. Vivamus interdum odio nec felis interdum mollis. Praesent et massa quis augue accumsan laoreet. Nullam ultrices, dui ac condimentum cursus, lectus elit molestie velit, vitae consequat elit arcu sed massa. Praesent at lacinia ante, varius lacinia urna. Donec pretium gravida nunc, sed congue mi tincidunt eu. Aenean ut diam eget orci dignissim placerat. Pellentesque fermentum aliquet velit et fermentum. Etiam ut risus dapibus, dictum augue ac, ornare metus."
        };

        /// <summary>
        /// String array of args that will trigger help text.
        /// </summary>
        public readonly static string[] HelpStrings =
        {
            "/?",
            "?",
            "/help",
            "help",
            "-help",
            "/huh",
            "huh",
            "-huh"
        };

        /// <summary>
        /// Dictionary of alphabetic to Morse code translation values.
        /// </summary>
        public readonly static Dictionary<char, string> MorseCode = new Dictionary<char, string>()
        {
            {'a', ".-"},
            {'b', "-..."},
            {'c', "-.-."},
            {'d', "-.."},
            {'e', "."},
            {'f', "..-."},
            {'g', "--."},
            {'h', "...."},
            {'i', ".."},
            {'j', ".---"},
            {'k', "-.-"},
            {'l', ".-.."},
            {'m', "--"},
            {'n', "-."},
            {'o', "---"},
            {'p', ".--."},
            {'q', "--.-"},
            {'r', ".-."},
            {'s', "..."},
            {'t', "-"},
            {'u', "..-"},
            {'v', "...-"},
            {'w', ".--"},
            {'x', "-..-"},
            {'y', "-.--"},
            {'z', "--.."},
            {'0', "-----"},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
            {'.',".-.-.-"},
            {',',"--.--"},
            {'?',"..--.."},
            {' ',"-...-"}
        };

        #region Binary Constrants

        /// <summary>
        /// Enum of the binary number types.
        /// </summary>
        public enum NumberType 
        {
            Bytes,
            KB, 
            MB,
            GB,
            TB,
            PB,
            EB,
            ZB,
            YB,
            BB,
            GpB,
            SB,
            PaB,
            AB,
            PlB,
            BrB,
            SoB,
            QB,
            KaB,
            RB,
            DB,
            HB,
            MrB,
            DdB,
            RtB,
            ShB,
            CB,
            KkB
        }

        /// <summary>
        /// Number of bits per byte.
        /// </summary>
        public const double BitsPerByte = 8;

        /// <summary>
        /// Number of bytes in a Kilobyte.
        /// </summary>
        public const double KB = 1024;

        /// <summary>
        /// Number of bytes in a Megabyte.
        /// </summary>
        public const double MB = KB * 1024;

        /// <summary>
        /// Number of bytes in a Gigabyte.
        /// </summary>
        public const double GB = MB * 1024;

        /// <summary>
        /// Number of bytes in a Terabyte.
        /// </summary>
        public const double TB = GB * 1024;

        /// <summary>
        /// Number of bytes in a Petabyte.
        /// </summary>
        public const double PB = TB * 1024;

        /// <summary>
        /// Number of bytes in a Exabyte.
        /// </summary>
        public const double EB = PB * 1024;

        /// <summary>
        /// Number of bytes in a Zettabyte.
        /// </summary>
        public const double ZB = EB * 1024;

        /// <summary>
        /// Number of bytes in a Yottabyte.
        /// </summary>
        public const double YB = ZB * 1024;

        /// <summary>
        /// Number of bytes in a Brontobyte.
        /// </summary>
        public const double BB = YB * 1024;

        /// <summary>
        /// Number of bytes in a Geopbyte.
        /// </summary>
        public const double GpB = BB * 1024;

        /// <summary>
        /// Number of bytes in a Saganbyte.
        /// </summary>
        public const double SB = GpB * 1024;

        /// <summary>
        /// Number of bytes in a Pijabyte.
        /// </summary>
        public const double PaB = SB * 1024;

        /// <summary>
        /// Number of bytes in a Alphabyte.
        /// </summary>
        public const double AB = PaB * 1024;

        /// <summary>
        /// Number of bytes in a Pectrolbyte.
        /// </summary>
        public const double PlB = AB * 1024;

        /// <summary>
        /// Number of bytes in a Bolgerbyte.
        /// </summary>
        public const double BrB = PlB * 1024;

        /// <summary>
        /// Number of bytes in a Sambobyte.
        /// </summary>
        public const double SoB = BrB * 1024;

        /// <summary>
        /// Number of bytes in a Quesabyte.
        /// </summary>
        public const double QB = SoB * 1024;

        /// <summary>
        /// Number of bytes in a Kinsabyte.
        /// </summary>
        public const double KaB = QB * 1024;

        /// <summary>
        /// Number of bytes in a Rutherbyte.
        /// </summary>
        public const double RB = KaB * 1024;

        /// <summary>
        /// Number of bytes in a Dubnibyte.
        /// </summary>
        public const double DB = RB * 1024;

        /// <summary>
        /// Number of bytes in a Hassiubyte.
        /// </summary>
        public const double HB = DB * 1024;

        /// <summary>
        /// Number of bytes in a Meitnerbyte.
        /// </summary>
        public const double MrB = HB * 1024;

        /// <summary>
        /// Number of bytes in a Darmstadbyte.
        /// </summary>
        public const double DdB = MrB * 1024;

        /// <summary>
        /// Number of bytes in a Roentbyte.
        /// </summary>
        public const double RtB = DdB * 1024;

        /// <summary>
        /// Number of bytes in a Sophobyte.
        /// </summary>
        public const double ShB = RtB * 1024;

        /// <summary>
        /// Number of bytes in a Coperbyte.
        /// </summary>
        public const double CB = ShB * 1024;

        /// <summary>
        /// Number of bytes in a Koentekbyte.
        /// </summary>
        public const double KkB = CB * 1024;

        #endregion Binary Constrants

        #region Cryptography

        /// <summary>
        /// List of encryption providers to use.
        /// </summary>
        public enum EncryptionProvider
        {
            AES,
            DES,
            DSA,
            MD5,
            RNG,
            RSA,
            SHA1,
            SHA256,
            SHA384,
            SHA512,
            TrippleDES
        }

        #endregion Cryptography

        /// <summary>
        /// Enum of possible enumerable types.
        /// </summary>
        public enum EnumerableType { Dictionary, NameValueCollection };
    }
}
