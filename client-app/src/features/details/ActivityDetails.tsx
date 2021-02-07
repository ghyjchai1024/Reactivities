import React from "react";
import { Button, Card, Image } from "semantic-ui-react";
import { IActivity } from "../../app/models/activity";

interface IPros {
  activity: IActivity;
  setEditMode: (editMode : boolean) => void;
  setSelectedActivity: (activity: IActivity | null) => void;
  submitting: boolean
}

const ActivityDetails: React.FC<IPros> = ({ activity, setEditMode,setSelectedActivity, submitting }) => {
  return (
    <Card fluid>
      <Image
        src={`/assets/categoryImages/${activity.category}.jpg`}
        wrapped
        ui={false}
      />
      <Card.Content>
        <Card.Header>{activity.title}</Card.Header>
        <Card.Meta>
          <span className="date">{activity.date}</span>
        </Card.Meta>
        <Card.Description>{activity.description}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button.Group fluid>
          <Button
            basic
            color="blue"
            content="Edit"
            onClick={() => setEditMode(true)}
          />
          <Button onClick={()=> setSelectedActivity(null)} basic color="grey" content="Cancel" />
        </Button.Group>
      </Card.Content>
    </Card>
  );
};

export default ActivityDetails;
