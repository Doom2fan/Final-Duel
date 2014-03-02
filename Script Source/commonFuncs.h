#define TICUNIT         35.725
// A bunch of functions that I've built up
// They come in handy :>
// by Ijon
function int abs(int x)
{
    if (x < 0) { return -x; }
    return x;
}

function int mod(int x, int y)
{
    int ret = x - ((x / y) * y);
    if (ret < 0) { ret = y + ret; }
    return ret;
}

function int pow(int x, int y)
{
    int n = 1;
    while (y-- > 0) { n *= x; }
    return n;
}

function int powFloat(int x, int y)
{
    int n = 1.0;
    while (y-- > 0) { n = FixedMul(n, x); }
    return n;
}

function int min(int x, int y)
{
    if (x < y) { return x; }
    return y;
}

function int max (int x, int y)
{
    if (x > y) { return x; }
    return y;
}

function int middle(int x, int y, int z)
{
    if ((x < z) && (y < z)) { return min(max(x, y), z); }
    return max(min(x, y), z);
}

function int keyUp(int key)
{
    int buttons = GetPlayerInput(-1, INPUT_BUTTONS);

    if (~buttons & key) { return 1; }
    return 0;
}

function int keyDown(int key)
{
    int buttons = GetPlayerInput(-1, INPUT_BUTTONS);

    if (buttons & key) { return 1; }
    return 0;
}

function int keyPressed(int key)
{
    int buttons     = GetPlayerInput(-1, INPUT_BUTTONS);
    int oldbuttons  = GetPlayerInput(-1, INPUT_OLDBUTTONS);
    int newbuttons  = (buttons ^ oldbuttons) & buttons;

    if (newbuttons & key) { return 1; }
    return 0;
}

function int adjustBottom(int tmin, int tmax, int i)
{
    if (i < tmin) { tmin = i; }
    if (i > tmax) { tmin += (i - tmax); }

    return tmin;
}

function int adjustTop(int tmin, int tmax, int i)
{
    if (i < tmin) { tmax -= (tmin - i); }
    if (i > tmax) { tmax = i; }

    return tmax;
}


function int quadPos(int a, int b, int c)
{
    int s1 = sqrt(FixedMul(b, b)-(4*FixedMul(a, c)));
    int s2 = (2 * a);
    int b1 = FixedDiv(-b + s1, s2);

    return b1;
}

function int quadNeg(int a, int b, int c)
{
    int s1 = sqrt(FixedMul(b, b)-(4*FixedMul(a, c)));
    int s2 = (2 * a);
    int b1 = FixedDiv(-b - s1, s2);

    return b1;
}

function int quadHigh(int a, int b, int c, int x)
{
    c -= x;
    return quadPos(a, b, c);
}

function int quadLow(int a, int b, int c, int x)
{
    c -= x;
    return quadNeg(a, b, c);
}

function int quad(int a, int b, int c, int y)
{
    return FixedMul(a, FixedMul(y, y)) + FixedMul(b, y) + y;
}

// Note: high is not inclusive because it's more useful that way
function int inRange(int low, int high, int x)
{
    return ((x >= low) && (x < high));
}

// CVar Functions
// Saving CVars, and automatically setting a CVar if it's 0
function void saveCVar(int cvar, int val)
{
    ConsoleCommand(StrParam(s:"set ", s:cvar, s:" ", d:val));
    ConsoleCommand(StrParam(s:"archivecvar ", s:cvar));
}

function int defaultCVar(int cvar, int defaultVal)
{
    int ret = GetCVar(cvar);
    if (ret == 0) { saveCVar(cvar, defaultVal); return defaultVal; }

    return ret;
}
// Saving and loading string CVars (no, seriously)
function void saveStringCVar(int string, int cvarname)
{
    int slen = StrLen(string);
    int i, c, cvarname2;

    for (i = 0; i < slen; i++)
    {
        cvarname2 = StrParam(s:cvarname, s:"_char", d:i);
        SaveCVar(cvarname2, GetChar(string, i));
    }

    while (1)
    {
        cvarname2 = StrParam(s:cvarname, s:"_char", d:i);
        c = GetCVar(cvarname2);

        if (c == 0) { break; }

        ConsoleCommand(StrParam(s:"unset ", s:cvarname2));
        i += 1;
    }
}
function int loadStringCVar(int cvarname)
{
    int ret = "";
    int i = 0, c, cvarname2;

    while (1)
    {
        cvarname2 = StrParam(s:cvarname, s:"_char", d:i);
        c = GetCVar(cvarname2);

        if (c == 0) { break; }

        ret = StrParam(s:ret, c:c);
        i += 1;
    }

    return ret;
}
// by Alex_mercer

// Summoning
function void Summon (str actor, int spottid, int tid, int angle)
{
	SpawnSpot(actor,spottid,tid,angle);
    SpawnSpot("TeleportFog",spottid,0,0);
}

// Infighting
function void Infight (int hate1, int hate2, int type)
{
	Thing_Hate(hate1,hate2,type);
    Thing_Hate(hate2,hate1,type);
}

// Health Boost
function void HealthBoost (int HP)
{
	Int currentHP = GetActorProperty(0,APROP_SpawnHealth);
	SetActorProperty(0,APROP_SpawnHealth,currentHP+HP);
}

// Health Unboost
function void HealthUnboost (int HP)
{
	Int currentHP = GetActorProperty(0,APROP_SpawnHealth);
	SetActorProperty(0,APROP_SpawnHealth,currentHP-HP);
}

// Take all stuff
function void RestartInventory (void)
{
	Int Chronos = CheckInventory("ChronosItem");
	TakeInventory("Sword", 1);
	TakeInventory("Magnum", 1);
	TakeInventory("FDShotgun", 1);
	TakeInventory("PumpActionShotgun", 1);
	TakeInventory("DoomSSG", 1);
	TakeInventory("QuadShotgun", 1);
	TakeInventory("AK47", 1);
	TakeInventory("ActionMachineGun", 1);
	TakeInventory("FDMinigun", 1);
	TakeInventory("FDRocketLauncher", 1);
	TakeInventory("FDGrenadeLauncher", 1);
	TakeInventory("FDPlasmaRifle", 1);
	TakeInventory("SonicRailgun", 1);
	TakeInventory("FDBFG9000", 1);
	TakeInventory("BFG10K", 1);
	TakeInventory("SoulReaper", 1);
	TakeInventory("Magic", 1);
	TakeInventory("MancubusArm", 1);
	TakeInventory("Clip2", 9999);
	TakeInventory("MagnumClip", 9999);
	TakeInventory("MinigunAmmo", 9999);
	TakeInventory("Shell2", 9999);
	TakeInventory("Slug", 9999);
	TakeInventory("RocketAmmo2", 9999);
	TakeInventory("GrenadeAmmo", 9999);
	TakeInventory("Cell2", 9999);
	TakeInventory("HellClip", 9999);
	TakeInventory("Energy", 9999);
	TakeInventory("DemonBlood", 9999);
	TakeInventory("BackpackItem", 9999);
	if(Chronos == 1)
	{
		GiveInventory("AmmoBeretta", 15);
		GiveInventory("AmmoActionMachinegun", 50);
	}
	if(Chronos == 0)
	{
		GiveInventory("EnforcerClip", 12);
		GiveInventory("EnforcerClipL", 12);
		GiveInventory("EnforcerClipR", 12);
	}
	GiveInventory("Clip2", 5);
	GiveInventory("Energy",100);
	GiveInventory("NVBattery", 100);
	GiveInventory("FDBerserk", 1);
	GiveInventory("AmmoMagnum", 6);
	GiveInventory("AmmoRifle", 30);
	GiveInventory("AmmoFDShotgun", 8);
	GiveInventory("AmmoPAShotgun", 6);
	GiveInventory("AmmoPAShotgunSlug", 6);
	GiveInventory("AmmoQuadShotgun", 4);
	GiveInventory("AmmoMinigun", 60);
	GiveInventory("AmmoGrenadeLauncher", 6);
	GiveInventory("AmmoPRifle", 80);
	GiveInventory("AmmoSRail", 80);
	GiveInventory("AmmoBFG10K", 80);
	GiveInventory("AmmoSR", 60);
	SetWeapon("Rifle");
}

function void RestartLevelSystem (void)
{
	TakeInventory("BerettaUpgrade", 1);
	TakeInventory("EnforcerUpgrade", 1);
	TakeInventory("MinigunUpgrade", 1);
	TakeInventory("NightvisionUpgrade", 1);
	TakeInventory("PlasmaRifleUpgrade", 1);
	if(CheckInventory("XPSystemLevel") >= 7) HealthUnboost(-50);
	TakeInventory("MagnumUpgrade", 1);
	TakeInventory("XPSystemLevel", 900000000);
	TakeInventory("XPSystemExperience", 900000000);
}

// Player move speed script made by DoomRater
// transformed into a function by Alex_Mercer
function void PlayerSpeed (int movespeed)
{
	SetActorProperty(0,APROP_Speed,movespeed*65535/100);
}

// I dunno who made this...
// I got it from ww-terror's Titlemap
function int HudMessageTime(int type, int length, int typetime, int staytime, int fadetime)
{
   Switch(type)
   {
   Case HUDMSG_PLAIN:
      return fixedmul(staytime, TICUNIT) >> 16;
   Case HUDMSG_FADEOUT:
      return fixedmul(staytime + fadetime, TICUNIT) >> 16;
   Case HUDMSG_TYPEON:
      return fixedmul(fixedmul(typetime, length << 16) + staytime + fadetime, TICUNIT) >> 16;
   Case HUDMSG_FADEINOUT:
      return fixedmul(typetime + staytime + fadetime, TICUNIT) >> 16;
   }
   return 0;
}

// From the ZDoom Wiki
// Hud Message on actor

function void hudmessageonactor(int tid, int range, str sprite, str text)
{
	int dist, ang, vang, pitch, x, y;
	int HUDX = 640;
	int HUDY = 400;
	int offset = 0;

	if(sprite != -1)
	{
		SetFont(sprite);
		text = "A";
		offset = 0.1;
	}

	SetHudSize(HUDX, HUDY, 1);
	x = GetActorX(tid) - GetActorX(0);
	y = GetActorY(tid) - GetActorY(0); 

	vang = VectorAngle(x,y);
	ang = (vang - GetActorAngle(0) + 1.0) % 1.0;

	if(((vang+0.125)%0.5) > 0.25) dist = FixedDiv(y, sin(vang));
	else dist = FixedDiv(x, cos(vang));

	if ((ang < 0.2 || ang > 0.8) && dist >> 16 < range)
	{
		pitch = VectorAngle(dist, GetActorZ(tid) - (GetActorZ(0) + 41.0));
		pitch = (pitch + GetActorPitch(0) + 1.0) % 1.0;

		x = HUDX/2 - ((HUDX/2) * sin(ang) / cos(ang));
		y = HUDY/2 - ((HUDX/2) * sin(pitch) / cos(pitch));

		HudMessage(s:text; HUDMSG_PLAIN, 1, CR_UNTRANSLATED, (x<<16)+offset, (y<<16)+offset, 0);
	}
	else
		HudMessage(s:""; HUDMSG_PLAIN, 1, CR_UNTRANSLATED, 0, 0, 0);
}