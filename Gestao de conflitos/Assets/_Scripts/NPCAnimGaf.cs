using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAF.Core
{
	public class NPCAnimGaf : MonoBehaviour {
		public GAFMovieClip gafClip;
		public string npcName;


		[ContextMenu("saetmna")]
		public void Senta(){
			gafClip.setSequence( npcName + "_senta", true);
		}

		public void SentaGato(){
			gafClip.stop();
			gafClip.setSequence( "gato_idle_computador", true);
			gafClip.reload();
		}

		[ContextMenu("_anda")]
		public void Anda(){
			gafClip.setSequence( npcName + "_anda", true);
		}

		[ContextMenu("_idle")]
		public void Idle(){
			gafClip.setSequence( npcName + "_idle", true);
		}

	}
}
