using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class TutorialScript : MonoBehaviour
    {
        public int Step = 0;
        public GameObject Panel;
        private TextMeshProUGUI ugui;
        private int tutorialStep = 0;
        private PlayerScript player;


        private readonly string[] texts = new[]
        {
            "You are alone on this planet filled with trash [space]",
            "You are a solar powered trash can [space]",
            "You are called... [space]",
            "Let's call you Will [space]",
            "You are called Will-y [space]",
            "As I said, you are solar powered, that means you need solar power to survive. [space]",
            "Keep an eye on your energy level. If you need to recharge just find a light spot and chill out there for a bit. [space]",
            "Your life goal and passion is (for whatever reason) collecting trash...  [space]",
            "If you find a trash pile pick it up (E) and bring it to the Trash Reactor(the towery looking thing). [space]",
            "Now go pick up some trash (E)",
            "Now go drop it at the reactor (E)",
            "Once You pick up all the trash you can move on with your life [space]",
            "Oh one more thing... [space]",
            "This should be pretty obvious, but don't touch the lava [space]",
            "Also (And I don't expect you to comprehend the concept) you are a ROBOT so keep away from the water [space]",
            "Water drains your energy. [space]",
            "Good luck ;) [space]",
        };


        // Start is called before the first frame update
        void Start()
        {
            ugui = Panel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            player = gameObject.GetComponent<PlayerScript>();
            ShowText(Step++);
            Time.timeScale = 0;
        }


        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                if (Step == 17)
                {
                    Time.timeScale = 1;
                }
                else if (Step < 9 || Step > 11)
                {
                    ShowText(Step++);
                }
                else if (Step == 9)
                {
                    ShowText(Step++);
                    Time.timeScale = 1;
                }
            }

            if (Input.GetKeyDown("e"))
            {
                if (Step == 10 && player.carryingTrash)
                {
                    ShowText(Step++);
                    Time.timeScale = 1;
                }
                else if (Step == 11 && player.carryingTrash == false)
                {
                    ShowText(Step++);
                }
            }
        }

        private void ShowText(int i)
        {
            Time.timeScale = 0;
            Panel.SetActive(true);
            ugui.SetText(texts[i]);
        }
    }
}