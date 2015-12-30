// <copyright file="BoxUserEventType.cs" company="itracks" >
//      Copyright (c) itracks All Right Reserved
// </copyright>
// <author>sean.gifford </author>
// <date>12/15/2015</date> 

using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Box.V2.Models
{
    /// <summary>
    /// The possible user event types
    /// </summary>
    public enum BoxUserEventType
    {
        /// <summary>
        /// A folder or File was created 
        /// </summary>
        [EnumMember(Value = "ITEM_CREATE")]
        ItemCreated,

        /// <summary>
        /// A folder or File was uploaded 
        /// </summary>
        [EnumMember(Value = "ITEM_UPLOAD")]
        ItemUploaded,

        /// <summary>
        /// A comment was created on a folder, file, or other comment
        /// </summary>
        [EnumMember(Value = "COMMENT_CREATE")]
        CommentCreated,

        /// <summary>
        /// A file or folder was downloaded
        /// </summary>
        [EnumMember(Value = "ITEM_DOWNLOAD")]
        ItemDownloaded,

        /// <summary>
        /// A file was previewed
        /// </summary>
        [EnumMember(Value = "ITEM_PREVIEW")]
        ItemPreviewed,

        /// <summary>
        /// A file or folder was moved
        /// </summary>
        [EnumMember(Value = "ITEM_MOVE")]
        ItemMoved,

        /// <summary>
        /// A file or folder was copied
        /// </summary>
        [EnumMember(Value = "ITEM_COPY")]
        ItemCopied,

        /// <summary>
        /// A task was assigned
        /// </summary>
        [EnumMember(Value = "TASK_ASSIGNMENT_CREATE")]
        TaskAssignmentCreated,

        /// <summary>
        /// A file was locked
        /// </summary>
        [EnumMember(Value = "LOCK_CREATE")]
        LockCreated,

        /// <summary>
        /// A file was unlocked
        /// </summary>
        [EnumMember(Value = "LOCK_DESTROY")]
        LockDestroyed,

        /// <summary>
        /// A file or folder was marked as deleted
        /// </summary>
        [EnumMember(Value = "ITEM_TRASH")]
        ItemDeleted,

        /// <summary>
        /// A file or folder was recovered out of the trash
        /// </summary>
        [EnumMember(Value = "ITEM_UNDELETE_VIA_TRASH")]
        ItemUndelete,

        /// <summary>
        /// A collaborator was added to a folder
        /// </summary>
        [EnumMember(Value = "COLLAB_ADD_COLLABORATOR")]
        CollaboratorAdded,

        /// <summary>
        /// A collaborator had their role changed
        /// </summary>
        [EnumMember(Value = "COLLAB_ROLE_CHANGE")]
        CollaboratorRoleChanged,

        /// <summary>
        /// A collaborator was invited on a folder
        /// </summary>
        [EnumMember(Value = "COLLAB_INVITE_COLLABORATOR")]
        CollaboratorInvited,

        /// <summary>
        /// A collaborator was removed from a folder
        /// </summary>
        [EnumMember(Value = "COLLAB_REMOVE_COLLABORATOR")]
        CollaboratorRemoved,

        /// <summary>
        /// A folder was marked for sync
        /// </summary>
        [EnumMember(Value = "ITEM_SYNC")]
        FolderMarkedForSync,

        /// <summary>
        /// A folder was un-marked for sync
        /// </summary>
        [EnumMember(Value = "ITEM_UNSYNC")]
        FolderUnmarkedForSync,

        /// <summary>
        /// A file or folder was renamed
        /// </summary>
        [EnumMember(Value = "ITEM_RENAME")]
        ItemRenamed,

        /// <summary>
        /// A file or folder was enabled for sharing
        /// </summary>
        [EnumMember(Value = "ITEM_SHARED_CREATE")]
        ItemShareEnabled,

        /// <summary>
        /// A file or folder was disabled for sharing
        /// </summary>
        [EnumMember(Value = "ITEM_SHARED_UNSHARE")]
        ItemShareDisabled,

        /// <summary>
        /// A folder was shared
        /// </summary>
        [EnumMember(Value = "ITEM_SHARED")]
        FolderShared,

        /// <summary>
        /// A Tag was added to a file or folder
        /// </summary>
        [EnumMember(Value = "TAG_ITEM_CREATE")]
        TagAdded,

        /// <summary>
        /// A user is logging in from a device we haven’t seen before
        /// </summary>
        [EnumMember(Value = "ADD_LOGIN_ACTIVITY_DEVICE")]
        LoginOnNewDevice,

        /// <summary>
        /// We invalidated a user session associated with an app
        /// </summary>
        [EnumMember(Value = "REMOVE_LOGIN_ACTIVITY_DEVICE")]
        LoginDeviceRemoved,

        /// <summary>
        /// When an admin role changes for a user
        /// </summary>
        [EnumMember(Value = "CHANGE_ADMIN_ROLE")]
        AdminRoleChanged,

        /// <summary>
        /// A collaborator violated an admin-set upload policy
        /// </summary>
        [EnumMember(Value = "CONTENT_WORKFLOW_UPLOAD_POLICY_VIOLATION")]
        UploadPolicyViolation
    }
}