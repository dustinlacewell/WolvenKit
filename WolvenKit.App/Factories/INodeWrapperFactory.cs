﻿using WolvenKit.App.ViewModels.GraphEditor.Quests.Nodes;
using WolvenKit.RED4.Types;

namespace WolvenKit.App.Factories;

public interface INodeWrapperFactory
{
    public questPhaseNodeDefinitionWrapper QuestPhaseNodeDefinitionWrapper(questPhaseNodeDefinition nodeDefinition);
    public questSceneNodeDefinitionWrapper QuestSceneNodeDefinitionWrapper(questSceneNodeDefinition nodeDefinition);
}