﻿using HipHopFile;
using System.Collections.Generic;
using System.ComponentModel;

namespace IndustrialPark
{
    public class DynaGObjectTalkBox : AssetDYNA
    {
        private const string dynaCategoryName = "game_object:talk_box";
        public override string TypeString => dynaCategoryName;

        protected override short constVersion => 11;

        [Category(dynaCategoryName)]
        public AssetID Dialog_TextBoxID { get; set; }
        [Category(dynaCategoryName)]
        public AssetID Prompt_TextBoxID { get; set; }
        [Category(dynaCategoryName)]
        public AssetID Quit_TextBoxID { get; set; }
        [Category(dynaCategoryName)]
        public bool Trap { get; set; }
        [Category(dynaCategoryName)]
        public bool Pause { get; set; }
        [Category(dynaCategoryName)]
        public bool AllowQuit { get; set; }
        [Category(dynaCategoryName)]
        public byte TriggerPads { get; set; }
        [Category(dynaCategoryName)]
        public bool Page { get; set; }
        [Category(dynaCategoryName)]
        public bool Show { get; set; }
        [Category(dynaCategoryName)]
        public bool Hide { get; set; }
        [Category(dynaCategoryName)]
        public bool AudioEffect { get; set; }
        [Category(dynaCategoryName)]
        public AssetID TeleportPointerID { get; set; }
        [Category(dynaCategoryName)]
        public bool AutoWaitTypeTime { get; set; }
        [Category(dynaCategoryName)]
        public bool AutoWaitTypePrompt { get; set; }
        [Category(dynaCategoryName)]
        public bool AutoWaitTypeSound { get; set; }
        [Category(dynaCategoryName)]
        public bool AutoWaitTypeEvent { get; set; }
        [Category(dynaCategoryName)]
        public AssetSingle AutoWaitDelay { get; set; }
        [Category(dynaCategoryName)]
        public int AutoWaitWhichEvent { get; set; }
        [Category(dynaCategoryName)]
        public AssetID PromptSkip_TextID { get; set; }
        [Category(dynaCategoryName)]
        public AssetID PromptNoSkip_TextID { get; set; }
        [Category(dynaCategoryName)]
        public AssetID PromptQuitTextID { get; set; }
        [Category(dynaCategoryName)]
        public AssetID PromptNoQuitTextID { get; set; }
        [Category(dynaCategoryName)]
        public AssetID PromptYesNoTextID { get; set; }

        public DynaGObjectTalkBox(string assetName, bool checkpointTalkbox) : base(assetName, DynaType.game_object__talk_box)
        {
            if (checkpointTalkbox)
            {
                Dialog_TextBoxID = 0x9BC49154;
                AutoWaitTypeTime = true;
                AutoWaitDelay = 2f;
            }
        }

        public DynaGObjectTalkBox(Section_AHDR AHDR, Game game, Endianness endianness) : base(AHDR, DynaType.game_object__talk_box, game, endianness)
        {
            using (var reader = new EndianBinaryReader(AHDR.data, endianness))
            {
                reader.BaseStream.Position = dynaDataStartPosition;

                Dialog_TextBoxID = reader.ReadUInt32();
                Prompt_TextBoxID = reader.ReadUInt32();
                Quit_TextBoxID = reader.ReadUInt32();
                Trap = reader.ReadByteBool();
                Pause = reader.ReadByteBool();
                AllowQuit = reader.ReadByteBool();
                TriggerPads = reader.ReadByte();
                Page = reader.ReadByteBool();
                Show = reader.ReadByteBool();
                Hide = reader.ReadByteBool();
                AudioEffect = reader.ReadByteBool();
                TeleportPointerID = reader.ReadUInt32();
                AutoWaitTypeTime = reader.ReadByteBool();
                AutoWaitTypePrompt = reader.ReadByteBool();
                AutoWaitTypeSound = reader.ReadByteBool();
                AutoWaitTypeEvent = reader.ReadByteBool();
                AutoWaitDelay = reader.ReadSingle();
                AutoWaitWhichEvent = reader.ReadInt32();
                PromptSkip_TextID = reader.ReadUInt32();
                PromptNoSkip_TextID = reader.ReadUInt32();
                PromptQuitTextID = reader.ReadUInt32();
                PromptNoQuitTextID = reader.ReadUInt32();
                PromptYesNoTextID = reader.ReadUInt32();
            }
        }

        protected override void SerializeDyna(EndianBinaryWriter writer)
        {
            writer.Write(Dialog_TextBoxID);
            writer.Write(Prompt_TextBoxID);
            writer.Write(Quit_TextBoxID);
            writer.Write(Trap);
            writer.Write(Pause);
            writer.Write(AllowQuit);
            writer.Write(TriggerPads);
            writer.Write(Page);
            writer.Write(Show);
            writer.Write(Hide);
            writer.Write(AudioEffect);
            writer.Write(TeleportPointerID);
            writer.Write(AutoWaitTypeTime);
            writer.Write(AutoWaitTypePrompt);
            writer.Write(AutoWaitTypeSound);
            writer.Write(AutoWaitTypeEvent);
            writer.Write(AutoWaitDelay);
            writer.Write(AutoWaitWhichEvent);
            writer.Write(PromptSkip_TextID);
            writer.Write(PromptNoSkip_TextID);
            writer.Write(PromptQuitTextID);
            writer.Write(PromptNoQuitTextID);
            writer.Write(PromptYesNoTextID);
        }
    }
}