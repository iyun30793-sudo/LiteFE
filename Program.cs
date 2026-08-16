using NAudio.Wave;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization.Metadata;
using System.Threading;

namespace SimpleRpg
{
    public delegate void Del();

    public abstract class AboutNum
    {

        // ==== 능력치 ====\\
       protected static float str;

        //==== 확률용 ====\\
       protected static float hit;
       protected static float crt;

    }

    interface IDmageable
    {
        void Damage(float damage);
    }


    internal class Program : AboutNum
    {

       public static float a = hit += 74;
       public static float b = crt += 10;
       public static float c = str += 9;

        public static int enymyHit;
        public static int enymyCrit;
        public static int enymyStr;

        public static string? name;

        public static bool isKillSward = false;
        static void Main()
        {
            


            Music m = new Music();
            m.Mucic();

            Console.WriteLine("     \\\\\\ ==* 행운의 일기토 *== ///");
            Console.WriteLine("           Press Any butten\n\n");
            Console.ReadKey(intercept: true);

            Console.WriteLine("당신이 좋아하는 이름을 적어주세요.");
            name = Console.ReadLine()!;

            switch (Program.name)
            {
                case "최현우":
                    a += 20;
                    b += 20; 
                    Console.WriteLine("특수이름!!! 명중률 20%, 필살율 20% 증가!!!\n");
                    break;
                case "링크":
                    b += 51;
                    Console.WriteLine("특수이름!!! 필살률 51% 증가!!!\n");
                    break;
                case "마르스":
                    c += 7;
                    Console.WriteLine("특수이름!!! 힘 7 증가!!!\n");
                    break;
                case "김두한":
                    PlayerHealth.Sadaller();
                    Console.WriteLine("4딸라!!!!: 상처약이 늘었다");
                    break;
                case "Null":
                    Console.WriteLine("제작자: 에엑따 Null을 불렀어 크악");
                    Console.WriteLine("NullReferenceException");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                    break;
            }

            WeaponSelect();

        }

        private static void WeaponSelect()
        {
            ConsoleKeyInfo key;

            Console.WriteLine("무기를 고르세요\n (키보드 1, 2, 3)");
            Task.Delay(100).Wait();
            Console.WriteLine("1. 킬소드: 명중률은 낮지만 필살 일격의 재격 운이 좋다면 뒤이은 공격을 노려볼지도....");
            Console.WriteLine("2. 은창: 모든 스탯이 균형있는 무기");
            Console.WriteLine("3. 크리티컬 액스: 명중률이 많이 낮아지지만 공격력과 필살률이 늘어난다.");

            while (true)
            {


                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.D1)
                {
                    c -= 3;
                    a -= 5;
                    b += 20;
                    isKillSward = true;
                    Console.WriteLine("킬소드를 얻었다.");
                    break;

                }
                else if (key.Key == ConsoleKey.D2)
                {
                    a += 6;
                    b -= 4;
                    c += 1;
                    Console.WriteLine("은창을 얻었다.");
                    break;

                }
                else if (key.Key == ConsoleKey.D3)
                {
                    a -= 40;
                    b += 30;
                    c += 12;

                    Console.WriteLine("크리티컬 액스를 얻었다.");
                    break;
                }
                else
                {
                    Console.WriteLine("삐삐 입력오류 키보드 1, 2, 3만 눌러주세요.");
                }
            }

                Thread.Sleep(500);
                Console.Clear();
                Robi();
        }

        public static void Robi()
        {
           
         

            ConsoleKeyInfo key;

            Console.WriteLine("\n\n무엇을 하시겠습니까? \n1. 체력회복 2. 공격하기");
            Task.Delay(100).Wait();
            Console.WriteLine("버튼: 1 / 2");

            while (true)
            {

                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.D1)
                {
                    PlayerHealth.Heal();
                    Game();
                    Console.Clear();
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("게임으로\n");
                    Thread.Sleep(100);

                    Game();
                    break;
                }
                else
                {
                    Console.WriteLine("삐삐 입력오류 키보드 1, 2만 눌러주세요.");
                }

            }

        }

       public static void Game()
        {

             ConsoleKeyInfo key;

            EnemyRnaStat ers = new();
            var (eH, eC, eS) = ers.EnemyRan();
            
            str = eS;
            hit = eH;
            crt = eC;

            Console.WriteLine("\n공격하시겠습니까? \n");
            Task.Delay(100).Wait();


            Console.WriteLine("┌──────────────────────────────────────┐");
            Console.WriteLine("│         |=| // 상황 \\\\ |=|           │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("│  \\\\ 플레이어 //          // 적 \\\\    │");
            Console.WriteLine($"│  HP  : {PlayerHealth.hp,2}/{PlayerHealth.maxhp,-2}          HP  : {EnemyHealth.hp,2}/{EnemyHealth.maxhp,-2}    │");
            Console.WriteLine($"│  Atk : {Program.c,-3}            Atk : {eS,-3}      │");
            Console.WriteLine($"│  Hit : {Program.a,-3}%           Hit : {eH,-3}%     │");
            Console.WriteLine($"│  Crt : {Program.b,-3}%           Crt : {eC,-3}%     │");
            Console.WriteLine("│                                      │");
            Console.WriteLine("└──────────────────────────────────────┘");

            Console.WriteLine("버튼: Y / N");

            while (true)
            {
               
                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Y)
                {
                    Del del = () => Console.WriteLine("공격\n");
                    
                    Attack(del);
                    break;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    Console.WriteLine("돌아간다\n");
                    Robi();
                    break;
                }
                else
                {
                    Console.WriteLine("삐삐 입력오류 키보드 영타로 Y나 N을 눌러주세요.");
                }

            }
        }

        private static void Attack(Del del)
        {
            Console.Clear();

        

            IDmageable Enemy = new EnemyHealth();
       
            RealHitRateCalculation real = new();

            del?.Invoke();

            var (x, y) = real.Calc();

           
            Task.Delay(500).Wait();
            
            if (x < a)
            {
                float final = c;
                if (y < b)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("히트!!!");
                    Task.Delay(500).Wait();
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("**!크리티컬!**");
                    Console.ResetColor();
                    final = c * 3;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("히트");
                    Console.ResetColor();
                }
                Enemy.Damage(final);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("미스.....");
                Console.ResetColor();
                Enemy.Damage(0);
            }

            Thread.Sleep(300);

            Counter();

        }


        private static void Counter()
        {
            Random aran = new();

            IDmageable player = new PlayerHealth();

            RealHitRateCalculation real = new();

            Console.WriteLine("적의 반격!!!\n");
            Thread.Sleep(750);

            var (x, y) = real.Calc();

            if (x < hit)
            {
                float finalDamage = str;

                // 치명타 여부 확인
                if (y < crt)
                {
                    finalDamage = str * 3; // 치명타시 배율 적용 (20)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("맞았다.");
                    Task.Delay(500).Wait();
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("** 치명타!!!!!! **");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("맞았다.");
                    Console.ResetColor();
                }

                // 데미지는 단 한 번만 적용
                player.Damage(finalDamage);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n미스");
                Console.ResetColor();
                Thread.Sleep(300);
            }

            Task.Delay(500).Wait();

           int rr = aran.Next(0, 100);
            if (rr < 36 && isKillSward)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n 추격!!!");
                Console.WriteLine("이어서 공격!!!");
                Thread.Sleep(750);
                Console.ResetColor();
                Console.Clear();
                SecoundAttack();
            }
            
            Game();

        }

        
        public static void SecoundAttack()
        {
            if (!isKillSward) return;

            

            IDmageable Enemy = new EnemyHealth();

            RealHitRateCalculation real = new();

            EnemyHealth.currentTurn -= 1;

            var (x, y) = real.Calc();


            Task.Delay(500).Wait();

            if (x < a)
            {
                float final = c;
                if (y < b)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("히트!!!");
                    Task.Delay(500).Wait();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**!크리티컬!**");
                    Console.ResetColor();
                    final = c * 3;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("히트");
                    Console.ResetColor();
                }
                Enemy.Damage(final);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("미스");
                Console.ResetColor();
                Enemy.Damage(0);
            }

            Thread.Sleep(300);

        }
    }

    class EnemyRnaStat()
    {
        Random r = new();
        public (int eHit, int eCrt, int eStr) EnemyRan()
        {
            int eHit = r.Next(40, 87);
            int eCrt = r.Next(0, 21);
            int eStr = r.Next(4, 16);

            return (eHit, eCrt, eStr);
        }
    }

    class RealHitRateCalculation
    {
        Random ran1 = new();
        Random ran2 = new();

        Random crtRate = new();



        public (int hit, int crt) Calc()
        {
           int hit = (ran1.Next(0, 100) + ran2.Next(0, 100)) / 2;
            int crt = crtRate.Next(0, 100);
            
            return (hit, crt);

        }
    }

    class PlayerHealth : IDmageable
    {
       public static float hp = 32;
      public  static float maxhp = 32;

      public static int healCount = 4;

        public static void Sadaller()
        {
            healCount += 4;
        }

        public void Damage(float damage)
        {
           hp -= damage;
            Console.WriteLine($"데미지: {damage} 현재체력:{hp}/32");
            Console.WriteLine($"현재 상처약 개수:{healCount}");
            Thread.Sleep(100);

            if (hp <= 0)
            {
                Console.WriteLine("쓰러졌다........");
                Thread.Sleep(100);
                GameOver();
            }

        }

        private void GameOver()
        {
            string deadplayer = $"{Program.name}: 아아 정말 죽어버리다니...";

            for(int k = 0; k < deadplayer.Length; k++)
            {
                Console.Write(deadplayer[k]);
                Thread.Sleep(100);
            }

            Console.ReadKey(intercept: true);
            Console.WriteLine("\n끝.......\n\n");

            Console.WriteLine("==//) Game Over (\\\\==");

            Console.ReadKey(intercept:true);
            Environment.Exit(0);
            return;
        }
        
        public static void Heal()
        {

            if (healCount > 0)
            {
                --healCount;
                hp = maxhp;
                Console.WriteLine("체력이 회복되었다.");
                Console.WriteLine($"현재 체력:{hp}");
            }
            else
            {
                Console.WriteLine("상처약이 동 났다.....");
            }
        }
        
    }

    class EnemyHealth : IDmageable
    {
       public static float hp = 82;
        public static float maxhp = 82;
       public static int currentTurn = 0;

        public void Damage(float damage)
        {
            hp -= damage;
            ++currentTurn;
            string dieMesseage = "으윽 원통하다.....";

            Console.WriteLine($"데미지:{damage} 적 체력:{hp}/82");
            Thread.Sleep(100);
            if(hp <= 0)
            {
                Thread.Sleep(750);
                Console.WriteLine("적 쓰러졌다!!!!");
                Thread.Sleep(800);
                Console.Write("적:");
                Task.Delay(100).Wait();
                for(int i = 0; i < dieMesseage.Length; i++)
                {
                    Console.Write(dieMesseage[i]);
                    Thread.Sleep(300);
                }
                Console.WriteLine();
                Console.ReadKey(intercept: true);
                Console.WriteLine();
                GameWin();
            }
        }

        private void GameWin()
        {
            string a = "당신은 승리했습니다. 플레이 해주셔서 감사합니다.";
            for(int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
                Thread.Sleep(100);
            }
            Console.WriteLine($"\n\n총 턴:{currentTurn}");
            if(currentTurn < 8)
            {
                Console.WriteLine("\n랭크:S");
                Thread.Sleep(70);
                string v = $"{Program.name}: 대단해 두 말 할것도 없어!!!";
                for (int i = 0; i < v.Length; i++)
                {
                    Console.Write(v[i]);
                    Thread.Sleep(50);
                }

                Console.WriteLine("\n하이랄의 용사\n");

            }
            else if(currentTurn >= 8 && currentTurn < 12) 
            {
                Console.WriteLine("\n랭크 A");
                Thread.Sleep(70);
                string v = $"{Program.name}: 좋은 결과일거야 분명";
                for (int i = 0; i < v.Length; i++)
                {
                    Console.Write(v[i]);
                    Thread.Sleep(50);
                }

                Console.WriteLine("\n특별한 이름: 영웅왕, 팔시온의 주인.\n");

            }
            else
            {
                Console.WriteLine("\n랭크 B");
                Thread.Sleep(70);
                string v = $"{Program.name}: 다음엔 더 잘할 수 있을거야";
                for(int i = 0; i < v.Length; i++)
                {
                    Console.Write(v[i]);
                    Thread.Sleep(100);
                }

                Console.WriteLine("\n특별한 이름: 종로의 패왕.\n");

            }
            Thread.Sleep(100);
            Console.WriteLine();
            string f = $"{Program.name}: 그거 알아? 특별한 이름에는 특별한 힘이 있데";
            for(int i = 0; i < f.Length; i++)
            {
                Console.Write(f[i]);
                Thread.Sleep(100);
            }

                Console.ReadKey(intercept: true);
            Environment.Exit(0);
     
        }
    }


    class Music
    { 
        public void Mucic()
        {
            
                var audio = new AudioFileReader("AttackTheme.mp3");

                var output = new WaveOutEvent();

                output.Init(audio);
                output.PlaybackStopped += (sender, e) =>  // <- 람다식 sender == e. e는 이벤트 sender는 object형
                {
                    audio.Position = 0;
                    output.Play();
                };

            output.Play();
        }

        
    }

}
