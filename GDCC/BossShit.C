bool bossBrainMonologueDone;

[[call("ScriptS"), extern("ACS")]]
void "FD_BossBrainMonologue" (void) {
	if (!getCVAR ("FD_NoBossMonologues")) {
		ACS_SetHudSize (640, 400, 0);
        ACS_SetFont ("BIGFONT");
        ACS_HudMessageBold (s:"In all my aeons"; HUDMSG_FADEOUT, 15, CR_WHITE, 320.4, 150.0, 5.5, 1.0);
		ACS_Delay (154);
		ACS_HudMessageBold (s:"I've never met anyone as foolish as you."; HUDMSG_FADEOUT, 15, CR_WHITE, 320.4, 150.0, 5.5, 1.0);
		ACS_Delay (154);
		ACS_HudMessageBold (s:"You might think the end is nigh"; HUDMSG_FADEOUT, 15, CR_WHITE, 320.4, 150.0, 5.5, 1.0);
		ACS_Delay (154);
		ACS_HudMessageBold (s:"But this is only the beginning."; HUDMSG_FADEOUT, 15, CR_WHITE, 320.4, 150.0, 5.5, 1.0);
		ACS_Delay (154);
		ACS_HudMessageBold (s:"Prepare to meet your doom."; HUDMSG_FADEOUT, 15, CR_WHITE, 320.4, 150.0, 5.5, 1.0);
		ACS_Delay (154);
	}
	
	bossBrainMonologueDone = true;
	ACS_SetActorState (0, "BossStart");
}

[[call("ScriptS"), extern("ACS")]]
void "FD_BossBrainWaitForMonologue" (void) {
	while (!BossBrainMonologueDone)
		ACS_Delay (1);
	
	ACS_SetActorState (0, "BossStart");
}