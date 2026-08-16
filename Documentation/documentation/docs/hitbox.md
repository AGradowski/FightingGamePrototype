# Hitbox Scripts

The folder for containg the documentation for anything relaed to the scripts connected to the Hitboxes

## HitboxDebuggerParent

The partent class, utilized as a Null Class (does nothing, and can be used in place of the HitboxDebugger, once debug is not needed).

## HitboxDebugger

### Variables

* public Material hitboxMaterial - the material used in displaying sphere in the Game view
* private List<GameObject\> debugHitboxes - the list of all the hitboxes genertated as part of the attack (debug only)
* private Player player - the reference to the player object

### Functions

* public override void GenerateVisualSphereHitbox(HitBox hitbox) - generates the hitbox sphere based on the [Hitbox](#hitbox) given
* public override void HideVisualHitbox() - destroys all the generated spheres and clears the list

## Player Scripts - Hitboxes

### Hitbox

* public Vector3 origin - the origing of the hitbox (center of the sphere). Will take into account the player position when returned by GetPosition() function
* bool sphereToggle (wip) - toggle whether the sphere is a Sphere or a Cube (now just Sphere is supported)
* public Vector3 hitboxSize (wip) - Vector of the cube sizes, at the moment not supported
* public float radius - the radius of the Sphere hitbox
* public int activeFrameOffset (wip) - which of the active frames will have this hitbox, currently not supported
* public Vector3 GetPositiion(Player player) - return the position of the hitbox based on the player position
* public float GetRadius() - radius getter

### HitBox Manager

* void OnDrawGizmosSelected() - draws the sphere gizmos in the scene when selected. USer can choose, which attack to display in the inpsector, changing the attackIndex variable
