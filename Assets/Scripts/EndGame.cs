using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EndGame {

	private static int vaccinesNeeded = 3;
	private static int vaccinesDelievered = 0;


	public static bool deliverVaccine() {
		vaccinesDelievered++;

		if (vaccinesDelievered == vaccinesNeeded) {
			return true;
		}

		return false;
	}
}
