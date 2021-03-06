import * as React from 'react';
import { Button, View, Text } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import LoginScreen from './src/screens/LoginScreen';
import MenuScreen from './src/screens/MenuScreen';
import CalendarScreen from './src/screens/CalendarScreen';
import ChatScreen from './src/screens/ChatScreen';
import CoursesScreen from './src/screens/CoursesScreen';
import GradesScreen from './src/screens/GradesScreen';
import PersonInfoScreen from './src/screens/PersonInfoScreen';
import ProfileScreen from './src/screens/ProfileScreen';
import ScheduleScreen from './src/screens/ScheduleScreen';
import SocietyScreen from './src/screens/SocietyScreen';
import CourseInfoScreen from './src/screens/CourseInfoScreen';
import CourseActionScreen from './src/screens/CourseActionScreen';
import UnImplementedScreen from './src/screens/UnImplementedScreen';


const Stack = createNativeStackNavigator();

function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="Login">
        <Stack.Screen name="Login" component={LoginScreen} />
        <Stack.Screen name="Menu" component={MenuScreen} />
        <Stack.Screen name="Grades" component={GradesScreen} />
        <Stack.Screen name="Society" component={SocietyScreen} />
        <Stack.Screen name="Chat" component={ChatScreen} />
        <Stack.Screen name="PersonInfoScreen" component={PersonInfoScreen} />
        {/* HERE STARTS UNIMPEMENTED SCREENS */}
        <Stack.Screen name="Profile" component={ProfileScreen} />
        <Stack.Screen name="Courses" component={CoursesScreen} />
        <Stack.Screen name="Schedule" component={ScheduleScreen} />
        <Stack.Screen name="Calendar" component={CalendarScreen} />
        <Stack.Screen name="CourseActionScreen" component={CourseActionScreen} />
        <Stack.Screen name="CourseInfoScreen" component={CourseInfoScreen} />
        <Stack.Screen name="UnImplementedScreen" component={UnImplementedScreen} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}

export default App;
