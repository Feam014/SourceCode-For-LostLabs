using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class Level1 : MonoBehaviour
{
    public Discord.Discord discord;

    void Start()
    {
        discord = new Discord.Discord(925470175187320883, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "In Level 1",
            State = "Beating the Tutorial",
            Timestamps =
            {
                Start = 5,
                End = 6,
            },
            Assets =
            {
                SmallImage = "Icon"
            }
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord status great");
            else
                Debug.LogError("Discord status failure");
        });
    }

    void Update()
    {
        discord.RunCallbacks();
    }
}
