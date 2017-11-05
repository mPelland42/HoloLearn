using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
	KeywordRecognizer keywordRecognizer = null;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	// Use this for initialization
	void Start()
	{
		keywords.Add("Center", () =>{
				this.BroadcastMessage("OnCenter");
			});
		keywords.Add ("Rotate", () => {
			this.BroadcastMessage("OnRotate");		
		});
		keywords.Add ("Stop", () => {
			this.BroadcastMessage("OnStop");		
		});
		keywords.Add ("delete", () => {
			this.BroadcastMessage("OnDelete");	
		});
		keywords.Add ("backspace", () => {
			this.BroadcastMessage("OnDelete");	
		});
		keywords.Add ("plane", () => {
			this.BroadcastMessage ("OnPlane");
		});
		keywords.Add ("saddle", () => {
			this.BroadcastMessage ("OnSaddle");
		});
		keywords.Add ("paraboloid", () => {
			this.BroadcastMessage ("OnParaboloid");
		});
		keywords.Add("graph", () =>{
			this.BroadcastMessage("OnGraph");
		});
		keywords.Add("go", () =>{
			this.BroadcastMessage("OnGo");
		});
		keywords.Add ("new", () => {
			this.BroadcastMessage("OnNew");	
		});
        keywords.Add("zero", () => {
            this.BroadcastMessage("On0");
        });
        keywords.Add("one", () => {
            this.BroadcastMessage("On1");
        });
        keywords.Add("two", () => {
            this.BroadcastMessage("On2");
        });
        keywords.Add("three", () => {
            this.BroadcastMessage("On3");
        });
        keywords.Add("four", () => {
            this.BroadcastMessage("On4");
        });
        keywords.Add("five", () => {
            this.BroadcastMessage("On5");
        });
        keywords.Add("six", () => {
            this.BroadcastMessage("On6");
        });
        keywords.Add("seven", () => {
            this.BroadcastMessage("On7");
        });
        keywords.Add("eight", () => {
            this.BroadcastMessage("On8");
        });
        keywords.Add("nine", () => {
            this.BroadcastMessage("On9");
        });


        keywords.Add ("x", () => {
			this.BroadcastMessage ("OnX");
		});
		keywords.Add ("y", () => {
			this.BroadcastMessage ("OnY");
		});
		keywords.Add ("open paren", () => {
			this.BroadcastMessage ("OnOpenParen");
		});
		keywords.Add ("close paren", () => {
			this.BroadcastMessage ("OnCloseParen");
		});
		keywords.Add ("times", () => {
			this.BroadcastMessage ("OnTimes");
		});
		keywords.Add ("divided by", () => {
			this.BroadcastMessage ("OnDividedBy");
		});
		keywords.Add ("plus", () => {
			this.BroadcastMessage ("OnPlus");
		});
		keywords.Add ("minus", () => {
			this.BroadcastMessage ("OnMinus");
		});
		keywords.Add ("to the power", () => {
			this.BroadcastMessage ("OnPower");
		});


		// Tell the KeywordRecognizer about our keywords.
		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

		// Register a callback for the KeywordRecognizer and start recognizing!
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
	}

	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;
		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();
		}
	}
}

/*using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
	public DictationRecognizer dictationRecognizer = null;

	// Use this for initialization
	void Start () {
		dictationRecognizer = new DictationRecognizer ();
		dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
		dictationRecognizer.Start ();


	}


	private void DictationRecognizer_DictationResult (string text, ConfidenceLevel confidence) {

		SurfaceDrawer.function = new BinaryExpression ("x");

	}
}*/