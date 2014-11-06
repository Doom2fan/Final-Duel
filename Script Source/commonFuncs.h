#define TICUNITS         35.725
// A bunch of functions that I've built up
// They come in handy :>
// by Ijon
function int abs (int x) {
    if (x < 0)
		return -x;
    return x;
}

function int mod (int x, int y) {
    int ret = x - ((x / y) * y);
    if (ret < 0)
		ret = y + ret;
    return ret;
}

function int pow (int x, int y) {
    int n = 1;
    while (y-- > 0)
		n *= x;
    return n;
}

function int powFloat (int x, int y) {
    int n = 1.0;
    while (y-- > 0)
		n = FixedMul(n, x);
    return n;
}

function int min (int x, int y) {
    if (x < y)
		return x;
    return y;
}

function int max (int x, int y) {
    if (x > y)
		return x;
    return y;
}

function int middle (int x, int y, int z) {
    if ((x < z) && (y < z))
		return min (max (x, y), z);
    return max (min (x, y), z);
}

function int keyUp (int key) {
    int buttons = GetPlayerInput (-1, INPUT_BUTTONS);

    if (~buttons & key)
		return 1;
    return 0;
}

function int keyDown (int key) {
    int buttons = GetPlayerInput (-1, INPUT_BUTTONS);

    if (buttons & key)
		return 1;
    return 0;
}

function int keyPressed (int key) {
    int buttons     = GetPlayerInput (-1, INPUT_BUTTONS);
    int oldbuttons  = GetPlayerInput (-1, INPUT_OLDBUTTONS);
    int newbuttons  = (buttons ^ oldbuttons) & buttons;

    if (newbuttons & key)
		return 1;
    return 0;
}

function int adjustBottom (int tmin, int tmax, int i) {
    if (i < tmin)
		tmin = i;
    if (i > tmax)
		tmin += (i - tmax);

    return tmin;
}

function int adjustTop (int tmin, int tmax, int i) {
    if (i < tmin)
		tmax -= (tmin - i);
    if (i > tmax)
		tmax = i;

    return tmax;
}


function int quadPos (int a, int b, int c) {
    int s1 = sqrt (FixedMul (b, b)-(4*FixedMul (a, c)));
    int s2 = (2 * a);
    int b1 = FixedDiv (-b + s1, s2);

    return b1;
}

function int quadNeg (int a, int b, int c) {
    int s1 = sqrt (FixedMul (b, b)-(4*FixedMul (a, c)));
    int s2 = (2 * a);
    int b1 = FixedDiv (-b - s1, s2);

    return b1;
}

function int quadHigh (int a, int b, int c, int x) {
    c -= x;
    return quadPos (a, b, c);
}

function int quadLow (int a, int b, int c, int x) {
    c -= x;
    return quadNeg (a, b, c);
}

function int quad (int a, int b, int c, int y) {
    return FixedMul (a, FixedMul (y, y)) + FixedMul (b, y) + y;
}

// Note: high is not inclusive because it's more useful that way
function int inRange (int low, int high, int x) {
    return ((x >= low) && (x < high));
}

// by Alex_mercer

// Summoning
function void Summon (str actor, int spottid, int tid, int angle) {
	SpawnSpot (actor, spottid, tid, angle);
    SpawnSpot ("TeleportFog", spottid, 0, 0);
}

// Infighting
function void Infight (int hate1, int hate2, int type) {
	Thing_Hate (hate1, hate2, type);
    Thing_Hate (hate2, hate1, type);
}

// Health Boost
function void HealthBoost (int HP) {
	Int currentHP = GetActorProperty (0, APROP_SpawnHealth);
	SetActorProperty (0, APROP_SpawnHealth, currentHP+HP);
}

// Health Unboost
function void HealthUnboost (int HP) {
	Int currentHP = GetActorProperty (0, APROP_SpawnHealth);
	SetActorProperty (0, APROP_SpawnHealth, currentHP-HP);
}

// Player move speed script made by DoomRater
// transformed into a function by Alex_Mercer
function void PlayerSpeed (int movespeed) {
	SetActorProperty (0, APROP_Speed, movespeed * 65535 / 100);
}

// I dunno who made this...
// I got it from ww-terror's Titlemap
function int HudMessageTime (int type, int length, int typetime, int staytime, int fadetime) {
	Switch (type) {
	Case HUDMSG_PLAIN:
		return fixedmul (staytime, TICUNITS) >> 16;
	Case HUDMSG_FADEOUT:
		return fixedmul (staytime + fadetime, TICUNITS) >> 16;
	Case HUDMSG_TYPEON:
		return fixedmul (fixedmul (typetime, length << 16) + staytime + fadetime, TICUNITS) >> 16;
	Case HUDMSG_FADEINOUT:
		return fixedmul (typetime + staytime + fadetime, TICUNITS) >> 16;
	}
	return 0;
}

// From the ZDoom Wiki
// Hud Message on actor

function void hudmessageonactor (int tid, int range, str sprite, str text) {
	int dist, ang, vang, pitch, x, y;
	int HUDX = 640;
	int HUDY = 400;
	int offset = 0;

	if (sprite != -1) {
		SetFont (sprite);
		text = "A";
		offset = 0.1;
	}

	SetHudSize (HUDX, HUDY, 1);
	x = GetActorX (tid) - GetActorX (0);
	y = GetActorY (tid) - GetActorY (0); 

	vang = VectorAngle (x,y);
	ang = (vang - GetActorAngle (0) + 1.0) % 1.0;

	if (((vang+0.125)%0.5) > 0.25)
		dist = FixedDiv (y, sin (vang));
	else
		dist = FixedDiv (x, cos (vang));

	if ((ang < 0.2 || ang > 0.8) && dist >> 16 < range) {
		pitch = VectorAngle (dist, GetActorZ (tid) - (GetActorZ (0) + 41.0));
		pitch = (pitch + GetActorPitch (0) + 1.0) % 1.0;

		x = HUDX/2 - ((HUDX/2) * sin(ang) / cos(ang));
		y = HUDY/2 - ((HUDX/2) * sin(pitch) / cos(pitch));

		HudMessage (s:text; HUDMSG_PLAIN, 1, CR_UNTRANSLATED, (x<<16)+offset, (y<<16)+offset, 0);
	}
	else
		HudMessage (s:""; HUDMSG_PLAIN, 1, CR_UNTRANSLATED, 0, 0, 0);
}