using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    #region Fields
    [SerializeField] private ScrollRect scrollRect;
    private List<RectTransform> items;
    private Vector2 newAnchoredPosition;
    private int itemCount = 0;

    private bool isVertical = false;
    private bool isHorizontal = false;
    private bool hasDisabledGridComponents = false;

    private float disableMarginX = 0;
    private float disableMarginY = 0;
    private float threshold = 5f;
    private float recordOffsetX = 0;
    private float recordOffsetY = 0;

    private VerticalLayoutGroup verticalLayoutGroup;
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private GridLayoutGroup gridLayoutGroup;
    private ContentSizeFitter contentSizeFitter;

    #endregion

    #region Core
    public void Initialize()
    {
        items = new List<RectTransform>();
        newAnchoredPosition = Vector2.zero;

        if (scrollRect != null)
        {
            isHorizontal = scrollRect.horizontal;
            isVertical = scrollRect.vertical;

            if (isHorizontal && isVertical)
            {
                print("Choose one direction (horizontal or vertical)");
            }

            setGridComponents();
            setItems();
        }
    }
    private void setGridComponents()
    {
        if (scrollRect.content.GetComponent<VerticalLayoutGroup>() != null)
        {
            verticalLayoutGroup = scrollRect.content.GetComponent<VerticalLayoutGroup>();
        }
        if (scrollRect.content.GetComponent<HorizontalLayoutGroup>() != null)
        {
            horizontalLayoutGroup = scrollRect.content.GetComponent<HorizontalLayoutGroup>();
        }
        if (scrollRect.content.GetComponent<GridLayoutGroup>() != null)
        {
            gridLayoutGroup = scrollRect.content.GetComponent<GridLayoutGroup>();
        }
        if (scrollRect.content.GetComponent<ContentSizeFitter>() != null)
        {
            contentSizeFitter = scrollRect.content.GetComponent<ContentSizeFitter>();
        }
    }
    private void setItems()
    {
        for (int i = 0; i < scrollRect.content.childCount; i++)
        {
            items.Add(scrollRect.content.GetChild(i).GetComponent<RectTransform>());
        }

        itemCount = scrollRect.content.childCount;
    }
    private void dismissAllLayoutGroup()
    {
        if (verticalLayoutGroup)
        {
            verticalLayoutGroup.enabled = false;
        }
        if (horizontalLayoutGroup)
        {
            horizontalLayoutGroup.enabled = false;
        }
        if (contentSizeFitter)
        {
            contentSizeFitter.enabled = false;
        }
        if (gridLayoutGroup)
        {
            gridLayoutGroup.enabled = false;
        }
    }
    private void disableGridComponents()
    {
        if (isVertical)
        {
            recordOffsetY = items[1].GetComponent<RectTransform>().anchoredPosition.y - items[0].GetComponent<RectTransform>().anchoredPosition.y;

            if (recordOffsetY < 0)
                recordOffsetY *= -1;

            disableMarginY = recordOffsetY * itemCount / 2;
        }

        if (isHorizontal)
        {
            recordOffsetX = items[1].GetComponent<RectTransform>().anchoredPosition.x - items[0].GetComponent<RectTransform>().anchoredPosition.x;

            if (recordOffsetX < 0)
                recordOffsetX *= -1;

            disableMarginX = recordOffsetX * itemCount / 2;
        }

        dismissAllLayoutGroup();

        hasDisabledGridComponents = true;
    }
    #endregion

    #region Executes
    public void SetNewItems(List<Transform> newItems, bool destroyBefore)
    {
        if (scrollRect != null)
        {
            if (scrollRect.content == null && newItems == null)
            {
                return;
            }

            if (destroyBefore)
            {
                if (items != null)
                {
                    items.Clear();
                }
                for (int i = scrollRect.content.childCount - 1; i >= 0; i--)
                {
                    RemoveChild(i);
                }
            }

            foreach (Transform newItem in newItems)
            {
                newItem.SetParent(scrollRect.content);
            }

            setItems();
        }
    }

    public void RemoveChild(int index)
    {
        Transform child = scrollRect.content.GetChild(index);
        child.SetParent(null);
        child.GetComponent<ScrollViewItem>().Dismiss();
        itemCount = scrollRect.content.childCount;
    }
    #endregion

    public void OnScroll(Vector2 pos)
    {
        if (!hasDisabledGridComponents)
            disableGridComponents();

        for (int i = 0; i < items.Count; i++)
        {
            if (isHorizontal)
            {
                if (scrollRect.transform.InverseTransformPoint(items[i].gameObject.transform.position).x > disableMarginX + threshold)
                {
                    newAnchoredPosition = items[i].anchoredPosition;
                    newAnchoredPosition.x -= itemCount * recordOffsetX;
                    items[i].anchoredPosition = newAnchoredPosition;
                    scrollRect.content.GetChild(itemCount - 1).transform.SetAsFirstSibling();
                }
                else if (scrollRect.transform.InverseTransformPoint(items[i].gameObject.transform.position).x < -disableMarginX)
                {
                    newAnchoredPosition = items[i].anchoredPosition;
                    newAnchoredPosition.x += itemCount * recordOffsetX;
                    items[i].anchoredPosition = newAnchoredPosition;
                    scrollRect.content.GetChild(0).transform.SetAsLastSibling();
                }
            }

            if (isVertical)
            {
                if (scrollRect.transform.InverseTransformPoint(items[i].gameObject.transform.position).y > disableMarginY + threshold)
                {
                    newAnchoredPosition = items[i].anchoredPosition;
                    newAnchoredPosition.y -= itemCount * recordOffsetY;
                    items[i].anchoredPosition = newAnchoredPosition;
                    scrollRect.content.GetChild(itemCount - 1).transform.SetAsFirstSibling();
                }
                else if (scrollRect.transform.InverseTransformPoint(items[i].gameObject.transform.position).y < -disableMarginY)
                {
                    newAnchoredPosition = items[i].anchoredPosition;
                    newAnchoredPosition.y += itemCount * recordOffsetY;
                    items[i].anchoredPosition = newAnchoredPosition;
                    scrollRect.content.GetChild(0).transform.SetAsLastSibling();
                }
            }
        }
    }
}
