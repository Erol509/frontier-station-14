﻿using Content.Shared.Roles;
using Content.Shared.Store; // Frontier: turn-in features
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared.Contraband;

/// <summary>
/// This is used for marking entities that are considered 'contraband' IC and showing it clearly in examine.
/// </summary>
[RegisterComponent, NetworkedComponent, Access(typeof(ContrabandSystem)), AutoGenerateComponentState]
public sealed partial class ContrabandComponent : Component
{
    /// <summary>
    ///     The degree of contraband severity this item is considered to have.
    /// </summary>
    [DataField]
    [AutoNetworkedField]
    public ProtoId<ContrabandSeverityPrototype> Severity = "Restricted";

    /// <summary>
    ///     Which departments is this item restricted to?
    ///     By default, command and sec are assumed to be fine with contraband.
    ///     If null, no departments are allowed to use this.
    /// </summary>
    [DataField]
    [AutoNetworkedField]
    public HashSet<ProtoId<DepartmentPrototype>>? AllowedDepartments = ["Security"];

    // Frontier: turn-in features
    /// <summary>
    ///     The set of currency types this item can be redeemed 
    /// </summary>
    [DataField]
    public Dictionary<ProtoId<CurrencyPrototype>, int> TurnInValues = new();
    // End Frontier: turn-in extensions
}
