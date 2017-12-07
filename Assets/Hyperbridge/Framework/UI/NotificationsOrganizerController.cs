﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hyperbridge.Profile;
public class NotificationsOrganizerController : MonoBehaviour {

    public VerticalLayoutGroup[] columns;
    public GridLayoutGroup grid;
    public GameObject notificationContainerPrefab;

    private void Awake()
    {
        CodeControl.Message.AddListener<UpdateProfilesEvent>(OnProfilesUpdated);
    }

    void OnProfilesUpdated(UpdateProfilesEvent e)
    {
        foreach (Transform child in columns[0].transform)
        {
            Destroy(child.gameObject);
        }
        if (e.activeProfile.notifications == null) return;

        if (e.activeProfile.notifications.Count <= 0) return;

        for (int i = 0; i < e.activeProfile.notifications.Count; i++)
        {
            GameObject newNotification = Instantiate(notificationContainerPrefab, columns[0].transform);
            newNotification.GetComponent<NotificationContainer>().SetupContainer(e.activeProfile.notifications[i].text, e.activeProfile.notifications[i].type, e.activeProfile.notifications[i].date, i);

        } 

        
    }


}