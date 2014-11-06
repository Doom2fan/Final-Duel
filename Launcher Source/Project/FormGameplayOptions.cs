﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Launcher {
    public partial class FormGameplayOptions : Form {
        public FormGameplayOptions () {
            InitializeComponent ();
        }

        #region ============ General ============

        private void comboBoxFallingDamage_SelectedIndexChanged (object sender, EventArgs e) {
            Game.Configurations.sv_fallingdamage = comboBoxFallingDamage.Text;
        }

        private void checkBoxDoubleAmmo_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_doubleammo = checkBoxDoubleAmmo.Checked;
        }

        private void checkBoxDropWeapon_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_weapondrop = checkBoxDropWeapon.Checked;
        }

        private void checkBoxInfiniteAmmo_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_infiniteammo = checkBoxInfiniteAmmo.Checked;
        }

        private void checkBoxInfiniteInventory_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_infiniteinventory = checkBoxInfiniteInventory.Checked;
        }

        private void checkBoxNoMonsters_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_nomonsters = checkBoxNoMonsters.Checked;
        }

        private void checkBoxKillAllMonsters_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_killallmonsters = checkBoxKillAllMonsters.Checked;
        }

        private void checkBoxMonstersRespawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_monsterrespawn = checkBoxMonstersRespawn.Checked;
        }

        private void checkBoxNoRespawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_norespawn = checkBoxNoRespawn.Checked;
        }

        private void checkBoxItemsRespawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_itemsrespawn = checkBoxItemsRespawn.Checked;
        }

        private void checkBoxRespawnSuper_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_respawnsuper = checkBoxRespawnSuper.Checked;
        }

        private void checkBoxFastMonsters_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_fastmonsters = checkBoxFastMonsters.Checked;
        }

        private void checkBoxDegeneration_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_degeneration = checkBoxDegeneration.Checked;
        }

        private void checkBoxAllowAutoaim_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_noautoaim = !checkBoxAllowAutoaim.Checked;
        }

        private void checkBoxAllowSuicide_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_disallowsuicide = !checkBoxAllowSuicide.Checked;
        }

        private void checkBoxAllowJump_CheckStateChanged (object sender, EventArgs e) {
            if (checkBoxAllowJump.CheckState == CheckState.Indeterminate)
                Game.Configurations.sv_jump = Trilean.Indeterminate;
            else if (checkBoxAllowJump.CheckState == CheckState.Checked)
                Game.Configurations.sv_jump = Trilean.True;
            else if (checkBoxAllowJump.CheckState == CheckState.Unchecked)
                Game.Configurations.sv_jump = Trilean.False;
        }

        private void checkBoxAllowCrouch_CheckStateChanged (object sender, EventArgs e) {
            if (checkBoxAllowCrouch.CheckState == CheckState.Indeterminate)
                Game.Configurations.sv_crouch = Trilean.Indeterminate;
            else if (checkBoxAllowCrouch.CheckState == CheckState.Checked)
                Game.Configurations.sv_crouch = Trilean.True;
            else if (checkBoxAllowCrouch.CheckState == CheckState.Unchecked)
                Game.Configurations.sv_crouch = Trilean.False;
        }

        private void checkBoxAllowFreelook_CheckStateChanged (object sender, EventArgs e) {
            if (checkBoxAllowFreelook.CheckState == CheckState.Indeterminate)
                Game.Configurations.sv_freelook = Trilean.Indeterminate;
            else if (checkBoxAllowFreelook.CheckState == CheckState.Checked)
                Game.Configurations.sv_freelook = Trilean.True;
            else if (checkBoxAllowFreelook.CheckState == CheckState.Unchecked)
                Game.Configurations.sv_freelook = Trilean.False;
        }

        private void checkBoxAllowFOV_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_nofov = !checkBoxAllowFOV.Checked;
        }

        private void checkBoxBFGAiming_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_nobfgaim = !checkBoxBFGAiming.Checked;
        }

        private void checkBoxAllowAutomap_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_noautomap = !checkBoxAllowAutomap.Checked;
        }

        private void checkBoxAutomapAllies_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_noautomapallies = !checkBoxAutomapAllies.Checked;
        }

        private void checkBoxAllowSpying_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_disallowspying = !checkBoxAllowSpying.Checked;
        }

        private void checkBoxChasecamCheat_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_chasecam = checkBoxChasecamCheat.Checked;
        }

        private void checkBoxDontCheckAmmo_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_dontcheckammo = !checkBoxDontCheckAmmo.Checked;
        }

        private void checkBoxKillBossMonst_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_killbossmonst = checkBoxKillBossMonst.Checked;
        }

        private void checkBoxNoCountEndMonst_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_nocountendmonst = !checkBoxNoCountEndMonst.Checked;
        }

        #endregion

        #region ============ Deathmatch ============

        private void checkBoxWeaponsStay_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_weaponstay = checkBoxWeaponsStay.Checked;
        }

        private void checkBoxAllowPowerups_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_noitems = !checkBoxAllowPowerups.Checked;
        }

        private void checkBoxAllowHealth_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_nohealth = !checkBoxAllowHealth.Checked;
        }

        private void checkBoxAllowArmor_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_noarmor = !checkBoxAllowArmor.Checked;
        }

        private void checkBoxSpawnFarthest_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_spawnfarthest = checkBoxSpawnFarthest.Checked;
        }

        private void checkBoxSameMap_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_samelevel = checkBoxSameMap.Checked;
        }

        private void checkBoxForceRespawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_forcerespawn = checkBoxForceRespawn.Checked;
        }

        private void checkBoxAllowExit_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_noexit = !checkBoxAllowExit.Checked;
        }

        private void checkBoxBarrelsRespawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_barrelrespawn = checkBoxBarrelsRespawn.Checked;
        }

        private void checkBoxRespawnProtection_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_respawnprotect = checkBoxRespawnProtection.Checked;
        }

        private void checkBoxLoseFrag_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_losefrag = checkBoxLoseFrag.Checked;
        }

        private void checkBoxKeepFrags_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_keepfrag = checkBoxKeepFrags.Checked;
        }

        private void checkBoxNoSwitching_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_noteamswitch = checkBoxNoSwitching.Checked;
        }

        #endregion

        #region ============ Cooperative ============

        private void checkBoxNoWeaponSpawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_noweaponspawn = !checkBoxNoWeaponSpawn.Checked;
        }

        private void checkBoxLoseInventory_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_cooploseinventory = checkBoxLoseInventory.Checked;
        }

        private void checkBoxKeepKeys_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_cooplosekeys = !checkBoxKeepKeys.Checked;
        }

        private void checkBoxKeepWeapons_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_cooploseweapons = !checkBoxKeepWeapons.Checked;
        }

        private void checkBoxKeepArmor_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_cooplosearmor = !checkBoxKeepArmor.Checked;
        }

        private void checkBoxKeepPowerups_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_cooplosepowerups = !checkBoxKeepPowerups.Checked;
        }

        private void checkBoxKeepAmmo_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_cooploseammo = !checkBoxKeepAmmo.Checked;
        }

        private void checkBoxHalfAmmo_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_coophalveammo = checkBoxHalfAmmo.Checked;
        }

        private void checkBoxSameSpawnSpot_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_samespawnspot = !checkBoxSameSpawnSpot.Checked;
        }

        #endregion
    }
}
